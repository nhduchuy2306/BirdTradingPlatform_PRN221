using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public int? Rating { get; set; }
        public string Status { get; set; }
        public int? OrderShopId { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual OrderShop OrderShop { get; set; }
        public virtual Product Product { get; set; }
    }
}
