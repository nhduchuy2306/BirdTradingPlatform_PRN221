using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            InverseOrderParent = new HashSet<Order>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? OrderParentId { get; set; }
        public int? OrderPaymentId { get; set; }
        public double? Total { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }

        public virtual Order OrderParent { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<Order> InverseOrderParent { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
