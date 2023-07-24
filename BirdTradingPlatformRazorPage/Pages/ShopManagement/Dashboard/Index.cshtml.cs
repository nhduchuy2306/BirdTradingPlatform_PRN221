using BussinessObject.Enum;
using BussinessObject.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly IOrderShopRepository _orderShopRepository;
        private readonly IUserRepository _userRepository;

        public IndexModel(IOrderShopRepository orderShopRepository, IUserRepository userRepository)
        {
            _orderShopRepository = orderShopRepository;
            _userRepository = userRepository;
        }

        [BindProperty]
        public List<OrderShopChartDto> OrderShopCharts { get; set; }

        [BindProperty]
        public string MonthEarnings { get; set; }

        [BindProperty]
        public string YearEarnings { get; set; }

        [BindProperty]
        public string TotalRequest { get; set; }

        public IActionResult OnGet()
        {
            string shopId = HttpContext.Session.GetString("ShopId");

            if (shopId == null)
            {
                return RedirectToPage("/Login");
            }

            OrderShopCharts = new List<OrderShopChartDto>();

            List<OrderShop> orderShops = _orderShopRepository.GetOrdersByShopId(
                int.Parse(shopId));
            List<ShopOrderRequestDTO> shopOrderRequestDTOs = new List<ShopOrderRequestDTO>();

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
                    Status = item.Order.Status
                });
            }

            TotalRequest = shopOrderRequestDTOs.Where(o => o.Status == "Processing").Count().ToString();

            List<int> distinctMonths = new List<int>
            {
                1, 2, 3, 4, 5,6, 7, 8, 9, 10, 11, 12
            };

            foreach (var month in distinctMonths)
            {
                var orderShopChart = orderShops
                    .Where(os => os.CreateDate.HasValue && os.CreateDate.Value.Month == month)
                    .GroupBy(os => os.ShopId)
                    .Select(g => new OrderShopChartDto
                    {
                        ShopId = g.Key,
                        MonthNumber = month,
                        MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                        TotalOrder = g.Sum(os => os.Total)
                    }).ToList();

                if (orderShopChart.Count == 0)
                {
                    OrderShopCharts.Add(new OrderShopChartDto
                    {
                        ShopId = int.Parse(shopId),
                        MonthNumber = month,
                        MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                        TotalOrder = 0
                    });
                }

                if (DateTime.Now.Month == month)
                {
                    MonthEarnings = orderShopChart.Sum(os => os.TotalOrder).ToString();
                }

                OrderShopCharts.AddRange(orderShopChart);
            }

            YearEarnings = OrderShopCharts.Sum(os => os.TotalOrder).ToString();

            return Page();
        }
    }
}
