using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProductImageDAO
    {
        public static List<ProductImage> GetProductImagesByProductId(int productId)
        {
            try
            {
                using var context = new BirdTradingPlatformContext();
                return context.ProductImages.Where(p => p.ProductId == productId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}