using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public int? AccountId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public DateTime? CreateDate { get; set; }
        public string AvatarUrl { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
