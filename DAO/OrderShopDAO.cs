using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class OrderShopDAO
    {
        public static List<OrderShop> GetOrdersByShopId(int shopId)
        {
            var orderShops = new List<OrderShop>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                orderShops = context.OrderShops.Where(o => o.ShopId == shopId)
                    .Include(o => o.Order)
                    .Include(o => o.Shop)
                    .OrderByDescending(o => o.Order.CreateDate)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderShops;
        }

        public static OrderShop AddOrderShop(OrderShop orderShop)
        {
            var newOrderShop = new OrderShop();
            try
            {
                using var context = new BirdTradingPlatformContext();
                newOrderShop = context.OrderShops.Add(orderShop).Entity;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newOrderShop;
        }

        public static OrderShop GetOrderShopById(int orderShopId)
        {
            var newOrderShop = new OrderShop();
            try
            {
                using var context = new BirdTradingPlatformContext();
                newOrderShop = context.OrderShops
                    .Include(o => o.Order)
                    .Include(o => o.Shop)
                    .SingleOrDefault(o => o.OrderShopId == orderShopId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newOrderShop;
        }
    }
}
