using AutoMapper;
using BussinessObject.Models;
using DAO;
using DTO;
using Repository.Interface;
using System.Collections.Generic;

namespace Repository.Implement
{
    public class OrderShopRepository : IOrderShopRepository
    {
        private readonly IMapper _mapper;

        public OrderShopRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public OrderShopDTO AddOrderShop(OrderShopDTO orderShopDTO)
        {
            OrderShop orderShop = _mapper.Map<OrderShop>(orderShopDTO);
            return _mapper.Map<OrderShopDTO>(OrderShopDAO.AddOrderShop(orderShop));
        }

        public OrderShop GetOrderShopById(int ShopId)
        {
            return OrderShopDAO.GetOrderShopById(ShopId);
        }

        public List<OrderShop> GetOrdersByShopId(int ShopId)
        {
            return OrderShopDAO.GetOrdersByShopId(ShopId);
        }
    }
}
