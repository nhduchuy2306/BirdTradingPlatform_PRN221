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

        public List<OrderDTO> orderDTO { get;set; }
        public List<UserDTO> userDTO { get;set; }

        public IActionResult OnGet()
        {
            userDTO = new List<UserDTO>();
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
            }

            return Page();
        }

        public IActionResult OnPostDeliveredDate(int OrderId, DateTime? DeliveredDate)
        {
            OrderDTO orderDTO = _orderRepository.GetOrderById(OrderId);

            if(DeliveredDate.Value.Day < orderDTO.OrderDate.Day)
            {
                TempData["DeliveredDate"] = "Delivered date must be after order date";
                return RedirectToPage("/ShopManagement/OrderRequest/Index");
            }

            orderDTO.Status = OrderEnum.Shipping.ToString();
            orderDTO.ShippedDate = DeliveredDate;

            _orderRepository.UpdateOrder(orderDTO);
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
