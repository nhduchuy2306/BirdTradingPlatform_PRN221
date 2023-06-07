using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ShopId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int rating { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; } = -1;
        public string Color { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string MadeIn { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public int State { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
