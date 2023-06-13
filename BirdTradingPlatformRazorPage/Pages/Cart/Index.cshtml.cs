using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace BirdTradingPlatformRazorPage.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public IndexModel(IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public List<CartItemDTO> cartItems { get; set; }

        public IActionResult OnGet()
        {
            string cart = HttpContext.Session.GetString("cart");
            if(cart == null)
            {
                cartItems = new List<CartItemDTO>();
            }
            else
            {
                cartItems = JsonSerializer.Deserialize<List<CartItemDTO>>(cart);
            }

            return Page();
        }

        public IActionResult OnGetRemoveItemFromCart(int productId)
        {
            string cart = HttpContext.Session.GetString("cart");

            if(cart == null)
            {
                cartItems = new List<CartItemDTO>();
                return Page();
            }

            cartItems = JsonSerializer.Deserialize<List<CartItemDTO>>(cart);

            cartItems.Remove(cartItems.FirstOrDefault(x => x.ProductId == productId));

            if(cartItems.Count == 0)
            {
                HttpContext.Session.Remove("cart");
                cartItems = new List<CartItemDTO>();
                return Page();
            }

            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartItems));

            return Page();
        }

        public IActionResult OnPostUpdateQuantity(int[] Quantities)
        {
            string cart = HttpContext.Session.GetString("cart");

            if (cart == null)
            {
                cartItems = new List<CartItemDTO>();
                return Page();
            }

            cartItems = JsonSerializer.Deserialize<List<CartItemDTO>>(cart);

            for (int i = 0; i < cartItems.Count; i++)
            {
                cartItems[i].Quantity = Quantities[i];
            }

            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartItems));

            return Page();
        }
    }
}
