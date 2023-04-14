using AutoMapper;
using CeeStore.BLL.ServicesContract;
using CeeStore.DAL.Entities;
using CeeStore.DAL.Repository;
using CeeStore.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CeeStore.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private AppUser? _user;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public AuthenticationService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IConfiguration configuration, IMapper mapper, ILoggerManager logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IdentityResult> RegisterBuyerAsync(BuyerForRegistrationDto buyerRequest)
        {
            try
            {
                _logger.LogInfo("Registering a buyer.");

                var userExists = await _userManager.FindByEmailAsync(buyerRequest.Email);
                if (userExists != null)
                {
                    throw new Exception("Email is already taken");
                }

                var buyerResult = _mapper.Map<AppUser>(buyerRequest);

                var buyer = await _userManager.CreateAsync(buyerResult, buyerRequest.Password);

                if (!buyer.Succeeded)
                {
                    var registrationError = buyer.Errors.Select(x => x.Description);
                    throw new Exception($"Unable to register a buyer \n{registrationError}");
                }

                await _userManager.AddToRoleAsync(buyerResult, "Buyer");
                return buyer;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IdentityResult> RegisterSellerAsync(SellerForRegistrationDto sellerRequest)
        {
            try
            {
                var sellerExists = await _userManager.FindByEmailAsync(sellerRequest.Email);

                if (sellerExists != null)
                {
                    throw new Exception("Email is already taken");
                }

                var sellerResult = _mapper.Map<AppUser>(sellerRequest);

                var seller = await _userManager.CreateAsync(sellerResult, sellerRequest.Password);

                if (!seller.Succeeded)
                {
                    var registrationError = seller.Errors.Select(x => x.Description);
                    throw new Exception($"Unable to register a seller \n{registrationError}");
                }

                await _userManager.AddToRoleAsync(sellerResult, "Seller");
                return seller;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IdentityResult> RegisterAdminAsync(AdminForRegistrationDto adminRequest)
        {
            try
            {
                var adminExists = await _userManager.FindByEmailAsync(adminRequest.Email);

                if (adminExists is not null)
                {
                    throw new Exception("Admin email already taken");
                }

                var adminResult = _mapper.Map<AppUser>(adminRequest);

                var admin = await _userManager.CreateAsync(adminResult, adminRequest.Password);

                if (!admin.Succeeded)
                {
                    var registrationError = admin.Errors.Select(x => x.Description);
                    throw new Exception($"Unable to register an admin \n{registrationError}");
                }

                await _userManager.AddToRoleAsync(adminResult, "Admin");
                return admin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userLogin)
        {
            _logger.LogInfo("validate user and logs them in");

            _user = await _userManager.FindByNameAsync(userLogin.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userLogin.Password));

            if (!result)
            {
                throw new Exception("Invalid username or password");
            }

            return result;
        }

        public async Task<string> CreateToken()
        {

            _logger.LogInfo("Creates the JWT token");

            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();


            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }

        private static SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

        }

        private async Task<List<Claim>> GetClaims()
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Id.ToString()),
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString())
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }



    }
}
