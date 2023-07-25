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
        private readonly IOrderShopRepository _orderShopRepository;

        public IndexModel(
            IOrderRepository orderRepository, 
            IShopRepository shopRepository, 
            IUserRepository userRepository,
            IOrderShopRepository orderShopRepository)
        {
            _orderRepository = orderRepository;
            _shopRepository = shopRepository;
            _userRepository = userRepository;
            _orderShopRepository = orderShopRepository;
        }

        public List<OrderDTO> orderDTO { get; set; }
        public List<UserDTO> userDTO { get; set; }
        public List<OrderShop> orderShops { get; set; }
        public List<ShopOrderRequestDTO> shopOrderRequestDTOs { get; set; }

        public IActionResult OnGet()
        {
            userDTO = new List<UserDTO>();
            string shopId = HttpContext.Session.GetString("ShopId");

            if (shopId == null)
            {
                return RedirectToPage("/Login");
            }

            orderShops = _orderShopRepository.GetOrdersByShopId(int.Parse(shopId));
            shopOrderRequestDTOs = new List<ShopOrderRequestDTO>();

            foreach (var item in orderShops)
            {
                UserDTO userDTO = _userRepository.GetUserById((int)item.Order.UserId);
                string paymentStatus = item.Order.PaymentStatus;

                shopOrderRequestDTOs.Add(new ShopOrderRequestDTO
                {
                    Username = userDTO.FullName,
                    Total = (double)item.Order.Total,
                    PaymentStatus = paymentStatus,
                    CreateDate = item.Order.CreateDate.ToString(),
                    Status = item.Order.Status,
                    OrderId = item.Order.OrderId,
                    OrderShopId = item.OrderShopId
                });
            }

            return Page();
        }

        public IActionResult OnGetDoneOrder(int orderId)
        {
            OrderDTO order = _orderRepository.GetOrderById(orderId);
            order.Status = "Delivered";
            _orderRepository.UpdateOrder(order);
            return RedirectToPage("/ShopManagement/OrderManagement/Index");
        }
    }
}
