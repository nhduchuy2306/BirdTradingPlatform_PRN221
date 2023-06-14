using AutoMapper;
using BussinessObject.Models;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;

        public OrderRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddOrder(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);
<<<<<<< Updated upstream
            order.PaymentMethod = null;
=======
>>>>>>> Stashed changes
            OrderDAO.AddOrder(order);
        }

        public OrderDTO AddOrderReturnObject(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);
            Order orderReturn = OrderDAO.AddOrderReturnObject(order);
            return _mapper.Map<OrderDTO>(orderReturn);
        }

<<<<<<< Updated upstream
        public List<OrderDTO> GetCompletedOrdersByShopId(int shopId)
        {
            List<Order> orders = OrderDAO.GetCompletedOrdersByShopId(shopId);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public OrderDTO GetOrderById(int orderId)
        {
            Order order = OrderDAO.GetOrderById(orderId);
            return _mapper.Map<OrderDTO>(order);
        }

        public List<OrderDTO> GetOrdersByShopId(int shopId)
        {
            List<Order> orders = OrderDAO.GetOrdersByShopId(shopId);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

=======
>>>>>>> Stashed changes
        public List<OrderDTO> GetOrdersByUserId(int userId)
        {
            List<Order> list = OrderDAO.GetOrdersByUserId(userId);
            return _mapper.Map<List<OrderDTO>>(list);
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);
            OrderDAO.UpdateOrder(order);
        }
    }
}