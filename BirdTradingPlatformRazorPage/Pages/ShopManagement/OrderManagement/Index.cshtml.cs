using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Repository.Interface;
using DTO;
using Microsoft.AspNetCore.Http;

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.OrderManagement
{
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public IndexModel(
            IOrderRepository orderRepository, 
            IShopRepository shopRepository, 
            IUserRepository userRepository,
            IPaymentMethodRepository paymentMethodRepository)
        {
            _orderRepository = orderRepository;
            _shopRepository = shopRepository;
            _userRepository = userRepository;
            _paymentMethodRepository = paymentMethodRepository;
        }

        public List<OrderDTO> orderDTO { get; set; }
        public List<UserDTO> userDTO { get; set; }

        public IActionResult OnGet()
        {
            userDTO = new List<UserDTO>();
            string shopId = HttpContext.Session.GetString("ShopId");

            if (shopId == null)
            {
                return RedirectToPage("/Login");
            }

            orderDTO = _orderRepository.GetCompletedOrdersByShopId(int.Parse(shopId));

            foreach (var item in orderDTO)
            {
                PaymentMethodDTO paymentMethod = _paymentMethodRepository.GetPaymentMethodById(item.PaymentMethodId);
                UserDTO user = _userRepository.GetUserById((int)paymentMethod.UserId);
                userDTO.Add(user);
            }

            return Page();
        }
    }
}
