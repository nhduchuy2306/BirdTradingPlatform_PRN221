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
    public class ShopRepository : IShopRepository
    {
        private readonly IMapper _mapper;

        public ShopRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ShopDTO GetShopById(int id)
        {
            Shop shop = ShopDAO.GetShopById(id);
            return _mapper.Map<ShopDTO>(shop);
        }

    }
}