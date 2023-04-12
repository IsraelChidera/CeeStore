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

                if (buyer.Succeeded)
                {
                    await _userManager.AddToRoleAsync(buyerResult, "Buyer");
                }
                
                return buyer;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
