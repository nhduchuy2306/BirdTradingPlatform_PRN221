using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class OrderDetailDAO
    {
        public static void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new BirdTradingPlatformContext();
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                orderDetails = context.OrderDetails
                    .Include(o => o.Product)
                    .Where(o => o.OrderId == orderId)
                    .ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }
    }
}