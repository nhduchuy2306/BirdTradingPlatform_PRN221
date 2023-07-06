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

        public ShopDTO(int? accountId, string shopName, string address, string avatarUrl, DateTime? createDate, string status)
        {
            AccountId = accountId;
            ShopName = shopName;
            Address = address;
            AvatarUrl = avatarUrl;
            CreateDate = createDate;
            Status = status;
        }
    }


}
