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
using System.Security.Cryptography;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.Xml;
using Microsoft.Extensions.Primitives;

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

        public IActionResult OnPostCodOrder()
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

                foreach (int shopId in shopIdsList)
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

                    foreach (var item in cartItems)
                    {
                        if (item.ShopId == shopId)
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

                            if (productDTO.Quantity >= item.Quantity)
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


        public IActionResult OnGetMoMoInfo(
            string partnerCode,
            string orderId,
            string requestId,
            string amount,
            string orderInfo,
            string orderType,
            string transId,
            string resultCode,
            string message,
            string payType,
            string responseTime,
            string extraData,
            string signature
        ){

            string accessKey = "yzp3lsHbJJifAkNU";
            string secretKey = "CJLOBZMb1CpjqpDl9bhA9zqnCTv2ThSY";

            var rawSignature = "accessKey=" + accessKey +
                               "&amount=" + amount +
                               "&extraData=" + extraData +
                               "&message=" + message +
                               "&orderId=" + orderId +
                               "&orderInfo=" + orderInfo +
                               "&orderType=" + orderType +
                               "&partnerCode=" + partnerCode +
                               "&payType=" + payType +
                               "&requestId=" + requestId +
                               "&responseTime=" + responseTime +
                               "&resultCode=" + resultCode +
                               "&transId=" + transId;

            string signRequest = getSignature(rawSignature, secretKey);

            if (!signRequest.Equals(signature))
            {
                ViewData["Message"] = "Order failed!";
            }
            else if (resultCode == "0")
            {
                string momoOrderId = orderId.Split(".")[1];
                Console.WriteLine("momoOrderId: " + momoOrderId);

                OrderDTO orderDTO = _orderRepository.GetOrderById(int.Parse(momoOrderId));
                orderDTO.PaymentStatus = PaymentEnum.Paid.ToString();

                _orderRepository.UpdateOrder(orderDTO);

                ViewData["Message"] = "Order success!";
                HttpContext.Session.Remove("cart");
                cartItems = new List<CartItemDTO>();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostMoMoOrder()
        {
            Guid myuuid = Guid.NewGuid();
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
                ViewData["Error"] = "You dont have any product!";
                HttpContext.Session.Remove("cart");
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

                foreach (int shopId in shopIdsList)
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

                    foreach (var item in cartItems)
                    {
                        if (item.ShopId == shopId)
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

                            if (productDTO.Quantity >= item.Quantity)
                            {
                                productDTO.Quantity -= item.Quantity;
                                _productRepository.UpdateProduct(productDTO);
                            }
                        }
                    }
                }

                string MoMoOrderId = myuuid.ToString() + "." + newOrderDTO.OrderId;

                string paymentUrl = await GetMoMoPaymentUrl(int.Parse(Total.ToString()) * 23000, MoMoOrderId);

                if (paymentUrl != null)
                {
                    return Redirect(paymentUrl);
                }
                else
                {
                    ViewData["Error"] = "Order failed!";
                }
            }
            return Page();
        }

        private async Task<string> GetMoMoPaymentUrl(int amount, string orderId)
        {
            HttpClient client = new HttpClient();
            Guid myuuid = Guid.NewGuid();

            string accessKey = "yzp3lsHbJJifAkNU";
            string secretKey = "CJLOBZMb1CpjqpDl9bhA9zqnCTv2ThSY";

            QuickPayRequest request = new QuickPayRequest();
            request.partnerCode = "MOMOI3J920220921";
            request.partnerName = "MoMo Payment";
            request.storeId = myuuid.ToString();
            request.requestId = myuuid.ToString(); ;
            request.amount = amount;
            request.orderId = orderId;
            request.orderInfo = "pay with MoMo";
            request.redirectUrl = "http://localhost:5000/Checkout?handler=MoMoInfo";
            request.ipnUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b";
            request.lang = "en";
            request.extraData = "";
            request.requestType = "captureWallet";

            var rawSignature = "accessKey=" + accessKey +
                               "&amount=" + request.amount +
                               "&extraData=" + request.extraData +
                               "&ipnUrl=" + request.ipnUrl +
                               "&orderId=" + request.orderId +
                               "&orderInfo=" + request.orderInfo +
                               "&partnerCode=" + request.partnerCode +
                               "&redirectUrl=" + request.redirectUrl +
                               "&requestId=" + request.requestId +
                               "&requestType=" + request.requestType;

            request.signature = getSignature(rawSignature, secretKey);

            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var quickPayResponse = await client.PostAsync("https://test-payment.momo.vn/v2/gateway/api/create", content);
            var contents = quickPayResponse.Content.ReadAsStringAsync().Result;

            QuickPayResponse response = JsonSerializer.Deserialize<QuickPayResponse>(contents);
            string payUrl = response.payUrl;

            return payUrl;
        }

        private string getSignature(string text, string key)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] textBytes = encoding.GetBytes(text);
            byte[] keyBytes = encoding.GetBytes(key);

            byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
