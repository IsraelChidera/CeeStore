using CeeStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.BLL.ServicesContract
{
    public interface IAuthenticationService
    {
        Task<string> RegisterBuyerAsync(BuyerForRegistrationDto buyerRequest);
    }
}
