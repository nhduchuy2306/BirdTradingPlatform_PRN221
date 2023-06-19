using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        public AccountDTO()
        {

        }

        public AccountDTO(int accountId, string phoneNumber, string password, string role, string status)
        {
            AccountId = accountId;
            PhoneNumber = phoneNumber;
            Password = password;
            Role = role;
            Status = status;
        }
        public AccountDTO( string phoneNumber, string password, string role, string status)
        {
            PhoneNumber = phoneNumber;
            Password = password;
            Role = role;
            Status = status;
        }
    }
}
