using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderShopDTO
    {
        public int OrderShopId { get; set; }
        public int? ShopId { get; set; }
        public int? OrderId { get; set; }
        public double? Total { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
