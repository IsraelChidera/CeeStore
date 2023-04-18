using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.Shared
{
    public class PaymentRequestDto
    {
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string PaymentReference { get; set; }
        public string CallbackUrl { get; set; }
    }
}
