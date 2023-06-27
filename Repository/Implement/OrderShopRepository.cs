﻿using AutoMapper;
using BussinessObject.Models;
using DAO;
using DTO;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
