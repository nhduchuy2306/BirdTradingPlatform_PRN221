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
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            ProductDAO.AddProduct(product);
        }

        public void DeleteProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            ProductDAO.DeleteProduct(product);
        }

        public List<ProductDTO> GetProductByCategoryId(int id)
        {
            List<Product> products = ProductDAO.GetProductByCategoryId(id);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public ProductDTO GetProductById(int id)
        {
            Product product = ProductDAO.GetProductById(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public List<ProductDTO> GetProducts()
        {
            List<Product> list = ProductDAO.GetProducts();
            return _mapper.Map<List<ProductDTO>>(list);
        }

        public List<ProductDTO> GetTop3Products()
        {
            List<Product> list = ProductDAO.GetTop3LatestProducts();
            return _mapper.Map<List<ProductDTO>>(list);
        }

        public void UpdateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            ProductDAO.UpdateProduct(product);
        }
    }
}