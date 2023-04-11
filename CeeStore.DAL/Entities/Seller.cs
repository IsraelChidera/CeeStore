using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.DAL.Entities
{
    public class Seller
    {
        public Guid SellerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessName { get; set; }
        public Guid UserId { get; set; }

        public AppUser User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
