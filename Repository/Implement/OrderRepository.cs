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

        public List<OrderDTO> GetOrdersByUserId(int userId)
        {
            List<Order> list = OrderDAO.GetOrdersByUserId(userId);
            return _mapper.Map<List<OrderDTO>>(list);
        }
    }
}