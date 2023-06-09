using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
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

        public UserDTO()
        {

        }

        public UserDTO( int? accountId, string fullName, string email, DateTime? dob, string gender, DateTime? createDate, string avatarUrl, string status, string address)
        {
            AccountId = accountId;
            FullName = fullName;
            Email = email;
            Dob = dob;
            Gender = gender;
            CreateDate = createDate;
            AvatarUrl = avatarUrl;
            Status = status;
            Address = address;
        }
    }
}
