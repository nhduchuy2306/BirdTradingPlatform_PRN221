using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int ProductId { get; set; }
        public int? ShopId { get; set; }
        public int? CategoryId { get; set; }
        public string ProductName { get; set; }
        public double? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int? Rating { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Species { get; set; }
        public int? Age { get; set; }
        public int? Size { get; set; }
        public int? Weight { get; set; }
        public DateTime? Expiration { get; set; }
        public string MadeIn { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string Status { get; set; }
        public string ProductImage { get; set; }

        public virtual Category Category { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
