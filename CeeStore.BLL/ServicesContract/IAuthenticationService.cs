using CeeStore.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.BLL.ServicesContract
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterBuyerAsync(BuyerForRegistrationDto buyerRequest);

        Task<IdentityResult> RegisterSellerAsync(SellerForRegistrationDto sellerRequest);
        Task<IdentityResult> RegisterAdminAsync(AdminForRegistrationDto adminRequest);
        Task<bool> ValidateUser(UserForAuthenticationDto userLogin);
        Task<string> CreateToken();
    }
}
