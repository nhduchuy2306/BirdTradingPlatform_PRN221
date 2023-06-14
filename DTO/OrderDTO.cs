using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? OrderParentId { get; set; }
        public double? Total { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
        public int? ShopId { get; set; }
        public string ShopName { get; set; }
        public string PaymentType { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
