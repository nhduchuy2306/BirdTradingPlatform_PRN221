using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShopDTO
    {
        public int ShopId { get; set; }
        public int? AccountId { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Status { get; set; }
    }
}
