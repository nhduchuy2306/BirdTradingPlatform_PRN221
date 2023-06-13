using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO
    {

        public static User GetUserByAccountId(int id)
        {
            User user = null;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    user = context.Users.Where(u => u.AccountId == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

            }
            return user;
        }
    }
}