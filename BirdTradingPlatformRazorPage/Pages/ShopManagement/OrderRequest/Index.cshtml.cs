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
using BussinessObject.Enum;

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.OrderRequest
{
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderShopRepository _orderShopRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IUserRepository _userRepository;

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

        public List<OrderDTO> orderDTO { get;set; }
        public List<UserDTO> userDTO { get;set; }
        public List<OrderShop> orderShops { get; set; }
        public List<ShopOrderRequestDTO> shopOrderRequestDTOs { get; set; }

        public IActionResult OnGet()
        {
            string shopId = HttpContext.Session.GetString("ShopId");
            orderShops = _orderShopRepository.GetOrdersByShopId(int.Parse(shopId)).Where(o => o.Order.Status.Equals("Processing")).ToList();
            shopOrderRequestDTOs = new List<ShopOrderRequestDTO>();

            foreach(var item in orderShops)
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
           /* userDTO = new List<UserDTO>();
            string shopId = HttpContext.Session.GetString("ShopId");

            if(shopId == null)
            {
                return RedirectToPage("/Login");
            }

            orderDTO = _orderRepository.GetOrdersByShopId(int.Parse(shopId));

            foreach(var item in orderDTO)
            {
                PaymentMethodDTO paymentMethod = _paymentMethodRepository.GetPaymentMethodById(item.PaymentMethodId);
                UserDTO user = _userRepository.GetUserById((int)paymentMethod.UserId);
                userDTO.Add(user);
            }*/

            return Page();
        }

        public IActionResult OnPostDeliveredDate(int OrderId, DateTime? DeliveredDate)
        {
            /*OrderDTO orderDTO = _orderRepository.GetOrderById(OrderId);

            if(DeliveredDate.Value.Day < orderDTO.OrderDate.Day)
            {
                TempData["DeliveredDate"] = "Delivered date must be after order date";
                return RedirectToPage("/ShopManagement/OrderRequest/Index");
            }

            orderDTO.Status = OrderEnum.Shipping.ToString();
            orderDTO.ShippedDate = DeliveredDate;

            _orderRepository.UpdateOrder(orderDTO);*/
            return RedirectToPage("/ShopManagement/OrderRequest/Index");
        }

        public IActionResult OnGetDeliveryOrder(int orderId)
        {
            OrderDTO order = _orderRepository.GetOrderById(orderId);
            order.Status = "Shipping";
            _orderRepository.UpdateOrder(order);
            return RedirectToPage("/ShopManagement/OrderRequest/Index");
        }

        public IActionResult OnGetCancelOrder(int orderId)
        {
            OrderDTO orderDTO = _orderRepository.GetOrderById(orderId);
            orderDTO.Status = OrderEnum.Cancelled.ToString();

            _orderRepository.UpdateOrder(orderDTO);

            return RedirectToPage("/ShopManagement/OrderRequest/Index");
        }
    }
}
