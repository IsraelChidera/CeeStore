using CeeStore.DAL.Enums;
using PayStack.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.BLL.ServicesContract
{
    public interface IOrderService
    {
        Task<TransactionInitializeResponse> CheckoutAsync(Guid carId, ShippingMethod shippingMethod);
    }
}
