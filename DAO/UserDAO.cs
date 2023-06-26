using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
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

        public static bool IsEmailExisted(string email)
        {
            bool status = false;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    status = context.Users.FirstOrDefault(c => c.Email == email) != null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return status;
        }

        public static bool IsEmailExisted(string email, int userId)
        {
            bool status = false;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    status = context.Users.FirstOrDefault(c => c.Email == email && 
                        c.UserId != userId) != null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return status;
        }

        public static bool AddNewUser(User user)
        {
            bool status = false;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                   context.Users.Add(user);
                   status = context.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return status;
        }

        public static bool UpdateUser(User user)
        {
            bool status = false;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    User user1 = context.Users.FirstOrDefault(u => u.UserId == user.UserId);
                    if(user != null)
                    {
                        user1.Address = user.Address;
                        user1.Email = user.Email;
                        user1.Dob= user.Dob;
                        user1.FullName = user.FullName;
                        user1.Gender = user.Gender;
                        user1.AvatarUrl = user.AvatarUrl;

                        status = context.SaveChanges() > 0;
                    }
                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return status;
        }
    }
}