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
                throw new Exception(e.Message);
            }
            return user;
        }

        public static User GetUserById(int userId)
        {
            User user = null;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    user = context.Users.FirstOrDefault(u => u.UserId == userId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }
    }
}