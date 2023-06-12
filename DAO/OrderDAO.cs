using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class OrderDAO
    {
        public static List<Order> GetOrdersByUserId(int userId)
        {
            List<Order> orders = new List<Order>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                orders = context.Orders
                    .Include(p => p.PaymentMethod)
                    .Include(p => p.OrderParent)
                    .Where(o => o.PaymentMethod.UserId == userId)
                    .Where(o => o.OrderParent != null)
                    .ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public static void AddOrder(Order order)
        {
            try
            {
                using var context = new BirdTradingPlatformContext();
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrder(Order order)
        {
            try
            {
                using var context = new BirdTradingPlatformContext();
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}