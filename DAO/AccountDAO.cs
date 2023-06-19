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

        public static bool AddNewAccount(Account account)
        {
            bool status = false;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    context.Accounts.Add(account);
                    status = context.SaveChanges() > 0;

                }
            }
            catch (Exception e)
            {

            }
            return status;
        }

        public static bool UpdateAccount(Account account)
        {
            bool status = false;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    Account account1= context.Accounts.FirstOrDefault(c => c.AccountId == account.AccountId);
                    account1.PhoneNumber = account.PhoneNumber;
                    account1.Password = account.Password;
                    status = context.SaveChanges() > 0;

                }
            }
            catch (Exception e)
            {

            }
            return status;
        }

        public static bool IsPhoneNumberExisted(string phoneNumber)
        {
            bool status = false;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    status = context.Accounts.FirstOrDefault(c =>  c.PhoneNumber == phoneNumber) != null;

                }
            }
            catch (Exception e)
            {

            }
            return status;
        }

        public static bool IsPhoneNumberExisted(string phoneNumber, int userId)
        {
            bool status = false;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    status = context.Accounts.FirstOrDefault(c => c.PhoneNumber == phoneNumber && c.Users.FirstOrDefault().UserId != userId) != null;

                }
            }
            catch (Exception e)
            {

            }
            return status;
        }

        public static Account GetAccountByUserId(int userId)
        {
            Account account = null;
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    account = context.Accounts.FirstOrDefault(c => c.Users.FirstOrDefault().UserId == userId);
                    
                }
            }
            catch (Exception e)
            {

            }
            return account;
        }

    }
}
