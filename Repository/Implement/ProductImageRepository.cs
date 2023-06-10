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
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly IMapper _mapper;

        public ProductImageRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ProductImageDTO> GetProductImagesByProductId(int productId)
        {
            List<ProductImage> proudtcImages = ProductImageDAO.GetProductImagesByProductId(productId);
            return _mapper.Map<List<ProductImageDTO>>(proudtcImages);
        }
    }
}