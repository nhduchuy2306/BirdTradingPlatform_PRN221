using BussinessObject.Enum;
using BussinessObject.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interface;
using System.Collections.Generic;
<<<<<<< Updated upstream
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interface;
using System.Collections.Generic;
=======
>>>>>>> Stashed changes
using System.Linq;
using System.Text.Json;
using System;

namespace BirdTradingPlatformRazorPage.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IProductRepository _productRepository;

        public IndexModel(
            IOrderDetailRepository orderDetailRepository, 
            IOrderRepository orderRepository, 
            IUserRepository userRepository, 
            IPaymentMethodRepository paymentMethodRepository,
            IProductRepository productRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _productRepository = productRepository;
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
<<<<<<< Updated upstream
            string userIdSession = HttpContext.Session.GetString("UserId");

            if(string.IsNullOrEmpty(userIdSession))
=======
            int userIdSession = HttpContext.Session.GetInt32("UserId") ?? 0;

            if(userIdSession == 0)
>>>>>>> Stashed changes
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
            else if (cart != null)
            {
                cartItems = JsonSerializer.Deserialize<List<CartItemDTO>>(cart);
<<<<<<< Updated upstream

                int userId = int.Parse(userIdSession);
=======
                int userId = userIdSession;
>>>>>>> Stashed changes
                PaymentMethodDTO paymentMethod = _paymentMethodRepository.GetPaymentMethodByUserId(userId);

                HashSet<int> shopIds = new HashSet<int>();

                foreach(var item in cartItems) 
                {
                    shopIds.Add(item.ShopId);
                }

                List<int> shopIdsList = shopIds.ToList();

                // Create first order, parent order
                int firstShopId = shopIdsList[0];

                OrderDTO orderFirst = new OrderDTO
                {
<<<<<<< Updated upstream
                    PaymentMethodId = paymentMethod.PaymentMethodId,
                    Total = 0,
                    ShopId = firstShopId,
                    OrderDate = DateTime.Now,
                    Status = OrderEnum.Processing.ToString(),
                    PaymentStatus = paymentMethod.PaymentType == PaymentType.COD.ToString() ? PaymentEnum.Unpaid.ToString() : PaymentEnum.Paid.ToString()
=======
                    OrderPaymentId = paymentMethod.PaymentMethodId,
                    Total = 0,
                    ShopId = firstShopId,
                    Status = OrderEnum.Processing.ToString(),
                    PaymentStatus = paymentMethod.PaymentType == PaymentType.COD.ToString() ? "Unpaid" : "Paid"
>>>>>>> Stashed changes
                };
                OrderDTO orderDTOFirstReturn = _orderRepository.AddOrderReturnObject(orderFirst);

                foreach (var item in cartItems)
                {
                    if (item.ShopId == firstShopId)
                    {
                        OrderDetailDTO orderDetail = new OrderDetailDTO
                        {
                            OrderId = orderDTOFirstReturn.OrderId,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Price = item.UnitPrice,
                            Status = OrderEnum.Processing.ToString()
                        };
                        _orderDetailRepository.AddOrderDetail(orderDetail);

                        ProductDTO productDTO = _productRepository.GetProductById(item.ProductId);

                        if(productDTO.Quantity < item.Quantity)
                        {
                            ViewData["Message"] = "Order failed! Product " + productDTO.ProductName + " is out of stock!";
                            return Page();
                        }

                        productDTO.Quantity -= item.Quantity;
                        _productRepository.UpdateProduct(productDTO);

                        orderDTOFirstReturn.Total += item.Quantity * item.UnitPrice;
                    }
                }
                _orderRepository.UpdateOrder(orderDTOFirstReturn);
                shopIdsList.RemoveAt(0);

                foreach (var shopId in shopIdsList)
                {
                    OrderDTO order = new OrderDTO
                    {
<<<<<<< Updated upstream
                        PaymentMethodId = paymentMethod.PaymentMethodId,
                        Status = OrderEnum.Processing.ToString(),
                        Total = 0,
                        OrderDate = DateTime.Now,
                        PaymentStatus = paymentMethod.PaymentType == PaymentType.COD.ToString() ? PaymentEnum.Unpaid.ToString() : PaymentEnum.Paid.ToString(),
=======
                        OrderPaymentId = paymentMethod.PaymentMethodId,
                        Status = OrderEnum.Processing.ToString(),
                        Total = 0,
                        PaymentStatus = paymentMethod.PaymentType == PaymentType.COD.ToString() ? "Unpaid" : "Paid",
>>>>>>> Stashed changes
                        ShopId = shopId,
                        OrderParentId = orderDTOFirstReturn.OrderId
                    };
                    OrderDTO orderDTOReturn = _orderRepository.AddOrderReturnObject(order);

                    foreach (var item in cartItems)
                    {
                        if (item.ShopId == shopId)
                        {
                            OrderDetailDTO orderDetail = new OrderDetailDTO
                            {
                                OrderId = orderDTOReturn.OrderId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                Price = item.UnitPrice,
                                Status = OrderEnum.Processing.ToString()
                            };
                            _orderDetailRepository.AddOrderDetail(orderDetail);

                            ProductDTO productDTO = _productRepository.GetProductById(item.ProductId);

                            if (productDTO.Quantity < item.Quantity)
                            {
                                ViewData["Message"] = "Order failed! Product " + productDTO.ProductName + " is out of stock!";
                                return Page();
                            }

                            productDTO.Quantity -= item.Quantity;
                            _productRepository.UpdateProduct(productDTO);

                            orderDTOReturn.Total += item.Quantity * item.UnitPrice;
                        }
                    }
                    _orderRepository.UpdateOrder(orderDTOReturn);
                }
                ViewData["Message"] = "Order success!";
                HttpContext.Session.Remove("cart");
            }
<<<<<<< Updated upstream
            return RedirectToPage("/Checkout/Index");
=======
            return Page();
>>>>>>> Stashed changes
        }
    }
}
