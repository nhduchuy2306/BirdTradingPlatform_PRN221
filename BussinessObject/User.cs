using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public Role Role { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
