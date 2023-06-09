using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderRepository
    {
        List<OrderDTO> GetOrdersByUserId(int userId);
        OrderDTO AddOrder(OrderDTO orderDTO);
        void UpdateOrder(OrderDTO orderDTO);
        OrderDTO GetOrderById(int orderId);
        List<OrderDTO> GetOrdersByShopId(int shopId);
        List<OrderDTO> GetCompletedOrdersByShopId(int shopId);
    }
}