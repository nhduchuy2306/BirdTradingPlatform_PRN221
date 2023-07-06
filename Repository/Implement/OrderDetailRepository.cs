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
            orderDetail.OrderShop = null;
            OrderDetailDAO.AddOrderDetail(orderDetail);
        }

        public void UpdateOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            OrderDetail orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            orderDetail.Product = null;
            orderDetail.OrderShop = null;
            OrderDetailDAO.UpdateOrderDetail(orderDetail);
        }

        public List<OrderDetailDTO> GetOrderDetailByOrderId(int id)
        {
            List<OrderDetail> list = OrderDetailDAO.GetOrderDetailByOrderId(id);
            return _mapper.Map<List<OrderDetailDTO>>(list);
        }

        public List<OrderDetailDTO> GetOrderDetailByOrderShopId(int orderShopId)
        {
            List<OrderDetail> orderDetailList = OrderDetailDAO.GetOrderDetailsByOrderShopId(orderShopId);
            return _mapper.Map<List<OrderDetailDTO>>(orderDetailList);
        }

        public OrderDetailDTO GetOrderDetailId(int id)
        {
            OrderDetail order = OrderDetailDAO.GetOrderDetailId(id);
            return _mapper.Map<OrderDetailDTO>(order);
        }
    }
}