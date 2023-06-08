using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class Shop
    {
        public Shop()
        {
            Products = new HashSet<Product>();
        }

        public int ShopId { get; set; }
        public int? AccountId { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Status { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
