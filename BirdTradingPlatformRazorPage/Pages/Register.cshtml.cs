using BussinessObject.Enum;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;

namespace BirdTradingPlatformRazorPage.Pages
{
    public class RegisterModel : PageModel
    {
        private IAccountRepository accountRepository;

        private IUserRepository userRepository;

        public RegisterModel(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            this.accountRepository = accountRepository;
            this.userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string PhoneNumber, string Password, string ConfirmPassword, string Email,
            string FullName, DateTime Dob, string Gender, string AvatarUrl, string Address) {
            if(accountRepository.IsPhoneNumberExited(PhoneNumber))
            {
                ViewData["PhoneError"] = "Phone Number existed!";
                return Page();
            }
            else
            {
                ViewData["PhoneError"] = null;
            }
            if(Password != ConfirmPassword)
            {
                ViewData["PasswordError"] = "Password and Confirm Password are not the same!";
                return Page();
            }
            else
            {
                ViewData["PasswordError"] = null;
            }
            if (userRepository.IsEmailExisted(Email))
            {
                ViewData["EmailError"] = "Email existed!";
                return Page();
            }
            else
            {
                ViewData["EmailError"] = null;
            }
            AccountDTO account = new AccountDTO( PhoneNumber, Password, RoleEnum.USER.ToString(),StatusEnum.ACTIVE.ToString());
            if (accountRepository.AddNewAccount(account))
            {
                account = accountRepository.GetAccountByPhoneNumberAndPassword(PhoneNumber, Password);
                UserDTO user = new UserDTO(account.AccountId, FullName, Email, Dob, Gender, DateTime.Now, AvatarUrl, StatusEnum.ACTIVE.ToString(), Address);
                if (userRepository.AddNewUser(user))
                {
                    return RedirectToPage("./Login");
                }
            }
            return Page();

        }

        

    }
}