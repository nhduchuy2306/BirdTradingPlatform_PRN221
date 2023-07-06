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
            orderDetail.Product = null;
            OrderDetailDAO.AddOrderDetail(orderDetail);
        }

        public List<OrderDetailDTO> GetOrderDetailByOrderId(int id)
        {
            /*List<OrderDetail> list = OrderDetailDAO.GetOrderDetailsByOrderId(id);
            return _mapper.Map<List<OrderDetailDTO>>(list);*/
            return null;
        }

        public List<OrderDetailDTO> GetOrderDetailByOrderShopId(int orderShopId)
        {
            List<OrderDetail> orderDetailList = OrderDetailDAO.GetOrderDetailsByOrderShopId(orderShopId);
            return _mapper.Map<List<OrderDetailDTO>>(orderDetailList);
        }
    }
}