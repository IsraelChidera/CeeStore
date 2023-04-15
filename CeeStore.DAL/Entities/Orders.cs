using CeeStore.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.DAL.Entities
{
    public class Orders
    {
        public Guid OrdersId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string? PaymentGateway { get; set; }
        public string? Reference { get; set; }
        public string? TransactionReference { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public string? shippingmethod { get; set; }

        public decimal ShippingCost { get; set; }

        public DateTime EstimateDeliveryDate { get; set; }
    }
}
