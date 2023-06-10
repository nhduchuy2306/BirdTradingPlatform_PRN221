using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PaymentMethodDTO
    {
        public int PaymentMethodId { get; set; }
        public int? UserId { get; set; }
        public string PaymentType { get; set; }
        public string PaymentNumber { get; set; }
        public string Status { get; set; }
    }
}
