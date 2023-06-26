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

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.OrderManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public DetailsModel(IOrderRepository orderRepository, IShopRepository shopRepository, IUserRepository userRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _shopRepository = shopRepository;
            _userRepository = userRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public OrderDTO orderDTO { get; set; }
        public UserDTO userDTO { get; set; }
        public List<OrderDetailDTO> orderDetailDTOs { get; set; }

        public IActionResult OnGet(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            orderDTO = _orderRepository.GetOrderById((int)id);

            PaymentMethodDTO paymentMethodDTO = _paymentMethodRepository.GetPaymentMethodById(orderDTO.PaymentMethodId);

            userDTO = _userRepository.GetUserById((int)paymentMethodDTO.UserId);

            orderDetailDTOs = _orderDetailRepository.GetOrderDetailByOrderId((int)id);

            if (orderDTO == null)
            {
                return NotFound();
            }*/
            return Page();
        }
    }
}
