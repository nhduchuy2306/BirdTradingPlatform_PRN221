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
        public int? UserId { get; set; }
        public double? Total { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
