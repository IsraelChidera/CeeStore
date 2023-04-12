using AutoMapper;
using CeeStore.BLL.ServicesContract;
using CeeStore.DAL.Entities;
using CeeStore.DAL.Repository;
using CeeStore.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IdentityResult> RegisterSellerAsync(SellerForRegistrationDto sellerRequest)
        {
            try
            {
                var sellerExists = await _userManager.FindByEmailAsync(sellerRequest.Email);

                if(sellerExists != null)
                {
                    throw new Exception("Email is already taken");
                }

                var sellerResult = _mapper.Map<AppUser>(sellerRequest);

                var seller = await _userManager.CreateAsync(sellerResult, sellerRequest.Password);

                if (!seller.Succeeded)
                {
                    var registrationError = seller.Errors.Select(x=>x.Description);
                    throw new Exception($"Unable to register a seller \n{registrationError}");
                }

                await _userManager.AddToRoleAsync(sellerResult, "Seller");
                return seller;

            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
