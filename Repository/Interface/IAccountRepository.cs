using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IAccountRepository
    {
        AccountDTO GetAccountByPhoneNumberAndPassword(string phoneNumber, string password);
    }
}
