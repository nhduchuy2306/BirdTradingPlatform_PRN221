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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IMapper _mapper;

        public OrderDetailRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            OrderDetail orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            OrderDetailDAO.AddOrderDetail(orderDetail);
        }
    }
}