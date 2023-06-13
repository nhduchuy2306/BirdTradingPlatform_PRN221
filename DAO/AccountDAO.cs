using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        public static Account GetAccountByPhoneNumberAndPassword(string PhoneNumber, string Password)
        {
            Account account = null;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    account = context.Accounts.Where(x => x.PhoneNumber.Trim() == PhoneNumber && x.Password.Trim() == Password).FirstOrDefault();

                }
            }
            catch (Exception e)
            {

            }
            return account;
        }
    }
}
