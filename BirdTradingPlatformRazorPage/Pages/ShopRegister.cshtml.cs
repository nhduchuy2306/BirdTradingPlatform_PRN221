using BussinessObject.Enum;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;

namespace BirdTradingPlatformRazorPage.Pages
{
    public class ShopRegisterModel : PageModel
    {
        private IAccountRepository accountRepository;

        private IShopRepository shopRepository;

        public ShopRegisterModel(IAccountRepository accountRepository, IShopRepository shopRepository)
        {
            this.accountRepository = accountRepository;
            this.shopRepository = shopRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string PhoneNumber, string Password, string ConfirmPassword,
            string ShopName,string AvatarUrl, string Address)
        {
            if (accountRepository.IsPhoneNumberExited(PhoneNumber))
            {
                ViewData["PhoneError"] = "Phone Number existed!";
                return Page();
            }
            else
            {
                ViewData["PhoneError"] = null;
            }
            if (Password != ConfirmPassword)
            {
                ViewData["PasswordError"] = "Password and Confirm Password are not the same!";
                return Page();
            }
            else
            {
                ViewData["PasswordError"] = null;
            }
            AccountDTO account = new AccountDTO(PhoneNumber, Password, RoleEnum.SHOP.ToString(), StatusEnum.ACTIVE.ToString());
            if (accountRepository.AddNewAccount(account))
            {
                account = accountRepository.GetAccountByPhoneNumberAndPassword(PhoneNumber, Password);
                ShopDTO shop = new ShopDTO(account.AccountId, ShopName, Address,AvatarUrl, DateTime.Now, StatusEnum.ACTIVE.ToString());
                if (shopRepository.AddNewShop(shop))
                {
                    return RedirectToPage("./Login");
                }
            }
            return Page();

        }

    }
}
