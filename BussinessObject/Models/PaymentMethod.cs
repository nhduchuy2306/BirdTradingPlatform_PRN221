using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentMethodId { get; set; }
        public int? UserId { get; set; }
        public string PaymentType { get; set; }
        public string PaymentNumber { get; set; }
        public string Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
