using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class OrderShop
    {
        public OrderShop()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderShopId { get; set; }
        public int? ShopId { get; set; }
        public int? OrderId { get; set; }
        public double? Total { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
