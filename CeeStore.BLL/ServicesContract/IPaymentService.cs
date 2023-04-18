using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.BLL.ServicesContract
{
    public interface IPaymentService
    {
        Task<string> MakePayment(string referenceCode);
    }
}
