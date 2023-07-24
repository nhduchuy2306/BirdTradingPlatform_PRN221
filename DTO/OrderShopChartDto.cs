using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderShopChartDto
    {
        public int? ShopId { get; set; }
        public int? MonthNumber { get; set; }
        public string MonthName { get; set; }
        public double? TotalOrder { get; set; }
    }
}
