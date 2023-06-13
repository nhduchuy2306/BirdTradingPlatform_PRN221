using BussinessObject.Enum;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;

namespace BirdTradingPlatformRazorPage.Pages
{
    public class LoginModel : PageModel
    {

        private readonly IAccountRepository _accountRepository;

        private readonly IUserRepository _userRepository;


        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public LoginModel(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            AccountDTO accountDTO = _accountRepository.GetAccountByPhoneNumberAndPassword(PhoneNumber, Password);
            if (accountDTO == null)
            {
                ViewData["Fail"] = "Phone number or Password is wrong!";
                return Page();
            }
            else
            {
                ViewData["Fail"] = null;
                HttpContext.Session.SetString("Role", accountDTO.Role);
                int userId = _userRepository.GetUserByAccountId(accountDTO.AccountId).UserId;
                HttpContext.Session.SetInt32("UserId", userId);

                if (userId != 0 && accountDTO.Role.Equals(RoleEnum.USER.ToString()))
                {
                    UserDTO userDTO = _userRepository.GetUserById(userId);

                    HttpContext.Session.SetString("UserName", userDTO.FullName);
                }

                string redirectTo = HttpContext.Session.GetString("RedirectTo");

                if(redirectTo != null)
                {
                    return RedirectToPage(redirectTo);
                }

                return RedirectToPage("/Index");
            }
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
