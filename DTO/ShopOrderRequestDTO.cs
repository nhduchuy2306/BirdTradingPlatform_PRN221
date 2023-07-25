using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShopOrderRequestDTO
    {
        public string Username { get; set; }
        public double Total { get; set; }
        public string PaymentStatus { get; set; }
        public string CreateDate { get; set; }
        public string Status { get; set; }

        public int OrderId { get; set; }

        public int OrderShopId { get; set; }
    }
}
