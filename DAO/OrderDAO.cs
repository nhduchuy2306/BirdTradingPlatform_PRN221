using BussinessObject.Enum;
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
        
        public static Order AddOrderReturnObject(Order order)
        {
            Order orderReturn = new Order();
            try
            {
                using var context = new BirdTradingPlatformContext();
                orderReturn = context.Orders.Add(order).Entity;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderReturn;
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

        public static void UpdateOrder(Order order)
        {
            try
            {
                using var context = new BirdTradingPlatformContext();
                context.Entry<Order>(order).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
<<<<<<< Updated upstream

        public static Order GetOrderById(int orderId)
        {
            Order order = new Order();
            try
            {
                using var context = new BirdTradingPlatformContext();
                order = context.Orders
                    .Include(p => p.PaymentMethod)
                    .Include(p => p.OrderParent)
                    .FirstOrDefault(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public static List<Order> GetOrdersByShopId(int shopId)
        {
            List<Order> orders = new List<Order>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                orders = context.Orders
                    .Include(p => p.PaymentMethod)
                    .Include(p => p.OrderParent)
                    .Where(o => o.ShopId == shopId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public static List<Order> GetCompletedOrdersByShopId(int shopId)
        {
            List<Order> orders = new List<Order>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                orders = context.Orders
                    .Include(p => p.PaymentMethod)
                    .Include(p => p.OrderParent)
                    .Where(o => o.ShopId == shopId &&
                        o.Status == OrderEnum.Delivered.ToString() &&
                        o.PaymentStatus == PaymentEnum.Paid.ToString())
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
=======
>>>>>>> Stashed changes
    }
}