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

        public static void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new BirdTradingPlatformContext();
                context.Entry(orderDetail).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<OrderDetail> GetOrderDetailsByOrderShopId(int orderShopId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                orderDetails = context.OrderDetails
                    .Include(o => o.Product)
                    .Where(o => o.OrderShopId == orderShopId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public static OrderDetail GetOrderDetailId(int id)
        {
            OrderDetail orderDetail = new OrderDetail();
            try
            {
                using var context = new BirdTradingPlatformContext();
                orderDetail = context.OrderDetails
                    .Include(o => o.OrderShop)
                    .Include(o => o.Product)
                    .Include(o => o.Product.Shop)
                    .FirstOrDefault(o => o.OrderDetailId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public static List<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                orderDetails = context.OrderDetails
                    .Include(o => o.OrderShop)
                    .Include(o => o.Product)
                    .Include(o => o.Product.Shop)
                    .Where(o => o.OrderShop.OrderId == orderId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        /*public static List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
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
        }*/
    }
}