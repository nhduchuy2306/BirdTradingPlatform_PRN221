using BussinessObject.Enum;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;
using System.Collections.Generic;

namespace BirdTradingPlatformRazorPage.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository userRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IShopRepository shopRepository;

        public IndexModel(IUserRepository userRepository, IAccountRepository accountRepository,
            IOrderRepository orderRepository, IShopRepository shopRepository)
        {
            this.userRepository = userRepository;
            this.accountRepository = accountRepository;
            this.orderRepository = orderRepository;
            this.shopRepository = shopRepository;
        }

        [BindProperty]
        public UserDTO UserDTO { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public AccountDTO AccountDTO { get; set; }
        public List<OrderDTO> orderDTO { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserId") == null || HttpContext.Session.GetString("Role") != "USER")
            {
                return RedirectToPage("../Login");
            }
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));
            UserDTO = userRepository.GetUserById(userId);
            Console.WriteLine(UserDTO.Gender);
            AccountDTO = accountRepository.GetAccountByUserId(userId);
            orderDTO = orderRepository.GetOrdersByUserId(userId);

            /*foreach (var item in orderDTO)
            {
                item.ShopName = shopRepository.GetShopById((int)item.ShopId).ShopName;
            }*/
            return Page();
        }

        public IActionResult OnPost()
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));
/*            if (accountRepository.IsPhoneNumberExited(PhoneNumber, userId))
            {
                ViewData["PhoneNumberError"] = "Phone number is existed!";
                return Page();
            }
            else
            {
                ViewData["PhoneNumberError"] = null;
            }*/
            if (userRepository.IsEmailExisted(UserDTO.Email, userId))
            {
                ViewData["EmailError"] = "Email existed!";
                return Page();
            }
            else
            {
                ViewData["EmailError"] = null;
            }
            UserDTO.UserId = userId;
            if(userRepository.UpdateUser(UserDTO)) {
                ViewData["UpdateSuccess"] = "Update success!";
                return Page();
            }

            return Page();
        }

        public IActionResult OnPostUpdateAccount(string ConfirmPassword, int AccountId)
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));
            ViewData["IsAccount"] = "display: none";
            if(AccountDTO.Password != ConfirmPassword)
            {
                ViewData["PasswordError"] = "Password is not match!";
                return Page();
            }
            else
            {
                ViewData["PasswordError"] = null;
            }   
            if(accountRepository.IsPhoneNumberExited(PhoneNumber, userId))
            {
                ViewData["PhoneNumberError"] = "Phone number is existed!";
                return Page();
            }
            else
            {
                ViewData["PhoneNumberError"] = null;
            }
            AccountDTO.AccountId = accountRepository.GetAccountByUserId(userId).AccountId;
            if(accountRepository.UpdateAccount(AccountDTO))
            {
                ViewData["UpdateSuccess"] = "Update success!";
                return Page();
            }
            return Page();
        }
        public IActionResult OnGetCheckReveivedProduct(int orderId)
        {
            /*OrderDTO orderDTO = orderRepository.GetOrderById(orderId);

            orderDTO.Status = OrderEnum.Delivered.ToString();
            orderDTO.PaymentStatus = PaymentEnum.Paid.ToString();
            if (orderDTO.ShippedDate == null)
                orderDTO.ShippedDate = DateTime.Now;

            orderRepository.UpdateOrder(orderDTO);*/

            return Page();
        }
    }
}
