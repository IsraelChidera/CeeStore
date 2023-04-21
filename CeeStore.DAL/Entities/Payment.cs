using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.DAL.Entities
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string PaymentReference { get; set; }
        public string CallbackUrl { get; set; }
        public Guid UserId { get; set; }
    }
}
