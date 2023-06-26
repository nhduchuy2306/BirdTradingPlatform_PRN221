using AutoMapper;
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
    }
}
