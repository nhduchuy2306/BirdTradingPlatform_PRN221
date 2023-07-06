using BussinessObject.Enum;
using BussinessObject.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System;
using System.Diagnostics;

namespace BirdTradingPlatformRazorPage.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderShopRepository _orderShopRepository;

        public IndexModel(
            IOrderDetailRepository orderDetailRepository, 
            IOrderRepository orderRepository, 
            IUserRepository userRepository,
            IProductRepository productRepository,
            IOrderShopRepository orderShopRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _orderShopRepository = orderShopRepository;
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

        public IActionResult OnPost()
        {
            string userIdSession = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdSession))
            {
                HttpContext.Session.SetString("RedirectTo", "/Checkout/Index");
                return RedirectToPage("/Login");
            }
            HttpContext.Session.Remove("RedirectTo"); // Remove "RedirectTo" session after login success

            string cart = HttpContext.Session.GetString("cart");

            if (cart == null)
            {
                cartItems = new List<CartItemDTO>();
            }
            else
            {
                cartItems = JsonSerializer.Deserialize<List<CartItemDTO>>(cart);
                int userId = int.Parse(userIdSession);

                double Total = 0;
                foreach (CartItemDTO item in cartItems)
                {
                    ProductDTO productDTO = _productRepository.GetProductById(item.ProductId);

                    if (productDTO.Quantity < item.Quantity)
                    {
                        ViewData["Error"] = "Not Enough Product: " + productDTO.ProductName;
                        return Page();
                    }

                    Total += item.Quantity * item.UnitPrice;
                }

                OrderDTO order = new OrderDTO
                {
                    UserId = userId,
                    Total = Total,
                    PaymentStatus = PaymentEnum.Unpaid.ToString(),
                    Status = OrderEnum.Processing.ToString(),
                    CreateDate = DateTime.Now,
                };

                OrderDTO newOrderDTO = _orderRepository.AddOrder(order);

                HashSet<int> shopIds = new HashSet<int>();

                foreach (var item in cartItems)
                {
                    shopIds.Add(item.ShopId);
                }

                List<int> shopIdsList = shopIds.ToList();

                foreach(int shopId in shopIdsList)
                {
                    double totalByShopId = cartItems.Where(x => x.ShopId == shopId)
                        .Sum(x => x.Quantity * x.UnitPrice);

                    OrderShopDTO orderShopDTO = new OrderShopDTO
                    {
                        ShopId = shopId,
                        OrderId = newOrderDTO.OrderId,
                        Total = totalByShopId,
                        CreateDate = DateTime.Now
                    };

                    OrderShopDTO newOrderShopDTO = _orderShopRepository.AddOrderShop(orderShopDTO);

                    foreach(var item in cartItems)
                    {
                        if(item.ShopId == shopId)
                        {
                            OrderDetailDTO orderDetailDTO = new OrderDetailDTO
                            {
                                OrderShopId = newOrderShopDTO.OrderShopId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                Price = item.UnitPrice,
                                CreateDate = DateTime.Now
                            };

                            _orderDetailRepository.AddOrderDetail(orderDetailDTO);

                            ProductDTO productDTO = _productRepository.GetProductById(item.ProductId);

                            if(productDTO.Quantity >= item.Quantity)
                            {
                                productDTO.Quantity -= item.Quantity;
                                _productRepository.UpdateProduct(productDTO);
                            }
                        }
                    }
                }
                ViewData["Message"] = "Order success!";
                HttpContext.Session.Remove("cart");
                cartItems = new List<CartItemDTO>();
            }
            return Page();
        }
    }
}
