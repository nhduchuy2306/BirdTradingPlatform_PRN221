using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System.Collections.Generic;
using System.Text.Json;

namespace BirdTradingPlatformRazorPage.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public IndexModel(
            IOrderDetailRepository orderDetailRepository, 
            IOrderRepository orderRepository, 
            IUserRepository userRepository, 
            IPaymentMethodRepository paymentMethodRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _paymentMethodRepository = paymentMethodRepository;
        }

        public List<CartItemDTO> cartItems { get; set; }

        public IActionResult OnGet()
        {
            string cart = HttpContext.Session.GetString("cart");

            if (cart == null)
            {
                cartItems = new List<CartItemDTO>();
            }
            else if (cart != null)
            {
                cartItems = JsonSerializer.Deserialize<List<CartItemDTO>>(cart);
            }

            return Page();
        }
    }
}
