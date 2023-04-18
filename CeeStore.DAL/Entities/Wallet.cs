using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.DAL.Entities
{
    public class Wallet
    {
        public Guid WalletId { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Balance { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey(nameof(AppUser))]
        public Guid UserId { get; set; }

        public AppUser User { get; set; }


    }
}
