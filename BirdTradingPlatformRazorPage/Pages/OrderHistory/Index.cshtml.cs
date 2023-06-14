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

namespace BirdTradingPlatformRazorPage.Pages.OrderHistory
{
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShopRepository _shopRepository;

        public IndexModel(IOrderRepository orderRepository, IShopRepository shopRepository)
        {
            _orderRepository = orderRepository;
            _shopRepository = shopRepository;
        }

        public List<OrderDTO> orderDTO { get;set; }

        public IActionResult OnGet()
        {
            string userId = HttpContext.Session.GetString("UserId");

            if (userId == null)
            {
                HttpContext.Session.SetString("RedirectTo", "/OrderHistory/Index");
                return RedirectToPage("/Login");
            }

            orderDTO = _orderRepository.GetOrdersByUserId(int.Parse(userId));

            foreach(var item in orderDTO)
            {
                item.ShopName = _shopRepository.GetShopById((int)item.ShopId).ShopName;
            }

            return Page();
        }

        public IActionResult OnGetCheckReveivedProduct(int orderId)
        {
            OrderDTO orderDTO = _orderRepository.GetOrderById(orderId);

            orderDTO.Status = OrderEnum.Delivered.ToString();
            orderDTO.PaymentStatus = PaymentEnum.Paid.ToString();
            if(orderDTO.ShippedDate == null)
                orderDTO.ShippedDate = DateTime.Now;

            _orderRepository.UpdateOrder(orderDTO);

            return RedirectToPage("/OrderHistory/Index");
        }
    }
}
