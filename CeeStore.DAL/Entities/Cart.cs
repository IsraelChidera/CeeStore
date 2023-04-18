using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.DAL.Entities
{
    public class Cart
    {
        public Guid CartId { get; set; }       
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
