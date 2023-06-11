using BussinessObject.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IProductRepository
    {
        List<ProductDTO> GetProducts();
        List<ProductDTO> GetTop3Products();
        List<ProductDTO> GetProductByCategoryId(int id);
        List<ProductDTO> GetProductByShopId(int id);
        List<ProductDTO> GetTop8Products();
        ProductDTO GetProductById(int id);
        void AddProduct(ProductDTO productDTO);
        void UpdateProduct(ProductDTO productDTO);
        void DeleteProduct(ProductDTO productDTO);
    }
}