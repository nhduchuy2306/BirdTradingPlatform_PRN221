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
        private readonly IShopRepository _shopRepository;


        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public LoginModel(IAccountRepository accountRepository, IUserRepository userRepository, IShopRepository shopRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _shopRepository = shopRepository;
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

                if (accountDTO.Role.Equals(RoleEnum.USER.ToString()))
                {
                    UserDTO userDTO = _userRepository.GetUserByAccountId(accountDTO.AccountId);
                    HttpContext.Session.SetString("UserId", userDTO.UserId.ToString());
                    HttpContext.Session.SetString("UserName", userDTO.FullName);
                }
                else if (accountDTO.Role.Equals(RoleEnum.SHOP.ToString()))
                {
                    ShopDTO shopDTO = _shopRepository.GetShopByAccountId(accountDTO.AccountId);
                    HttpContext.Session.SetString("ShopId", shopDTO.ShopId.ToString());
                    HttpContext.Session.SetString("ShopName", shopDTO.ShopName);

                    return Redirect("/ShopManagement/OrderRequest");
                }
                else if (accountDTO.Role.Equals(RoleEnum.STAFF.ToString()))
                {
                    HttpContext.Session.SetString("StaffId", accountDTO.AccountId.ToString());

                    return Redirect("/AdminManagement/ProductManagement");
                }

                string redirectTo = HttpContext.Session.GetString("RedirectTo");

                if (redirectTo != null)
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
