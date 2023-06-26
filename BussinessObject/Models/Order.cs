using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderShops = new HashSet<OrderShop>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public double? Total { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderShop> OrderShops { get; set; }
    }
}
