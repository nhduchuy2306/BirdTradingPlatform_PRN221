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
        private readonly IOrderShopRepository _orderShopRepository;

        public DetailsModel(IOrderRepository orderRepository, IShopRepository shopRepository, IUserRepository userRepository, IOrderDetailRepository orderDetailRepository, IOrderShopRepository orderShopRepository)
        {
            _orderRepository = orderRepository;
            _shopRepository = shopRepository;
            _userRepository = userRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderShopRepository = orderShopRepository;
        }

        public OrderShop orderShop { get; set; }
        public UserDTO userDTO { get; set; }
        public List<OrderDetailDTO> orderDetailDTOs { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            orderDetailDTOs = _orderDetailRepository.GetOrderDetailByOrderShopId((int)id);
            orderShop = _orderShopRepository.GetOrderShopById((int)id);
            userDTO = _userRepository.GetUserById((int)orderShop.Order.UserId);

            if (orderShop == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
