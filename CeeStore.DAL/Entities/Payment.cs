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
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string PaymentRef { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        [ForeignKey(nameof(AppUser))]
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
