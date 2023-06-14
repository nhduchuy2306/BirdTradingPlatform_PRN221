using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class Account
    {
        public Account()
        {
            Shops = new HashSet<Shop>();
            Users = new HashSet<User>();
        }

        public int AccountId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
