using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                products = context.Products
                            .Include(p => p.Category)
                            .Include(p => p.Shop)
                            .AsNoTracking()
                            .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static List<Product> GetProductPaginatin(int totalPage, int pageSize)
        {
            var products = new List<Product>();
            using var context = new BirdTradingPlatformContext();
            pageSize = pageSize > 0 ? pageSize : 1;
            totalPage = totalPage > 0 ? totalPage : 1;
            products = context.Products
                        .Include(p => p.Category)
                        .Include(p => p.Shop)
                        .AsNoTracking()
                        .Skip((totalPage - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
            return products;
        }

        public static IQueryable<Product> GetQueryProduct()
        {
            using var context = new BirdTradingPlatformContext();
            return context.Products
                        .Include(p => p.Category)
                        .Include(p => p.Shop)
                        .AsNoTracking();
        }

        public static Product GetProductById(int id)
        {
            var product = new Product();
            try
            {
                using var context = new BirdTradingPlatformContext();
                product = context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Shop)
                    .FirstOrDefault(p => p.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public static void AddProduct(Product product)
        {
            try
            {
                using var context = new BirdTradingPlatformContext();
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateProduct(Product product)
        {
            try
            {
                using var context = new BirdTradingPlatformContext();
                context.Entry<Product>(product).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProduct(Product product)
        {
            try
            {
                using var context = new BirdTradingPlatformContext();
                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<Product> GetTop3LatestProducts()
        {
            var products = new List<Product>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                products = context.Products.OrderByDescending(p => p.ProductId).Take(3).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static List<Product> GetProductByCategoryId(int id)
        {
            var products = new List<Product>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                products = context.Products.Where(p => p.CategoryId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static List<Product> GetProductByShopId(int id)
        {
            var products = new List<Product>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                products = context.Products.Where(p => p.ShopId == id).OrderByDescending(p => p.ProductId).Take(4).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static List<Product> GetTop8Products()
        {
            var products = new List<Product>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                products = context.Products.OrderByDescending(p => p.ProductId)
                    .Include(p => p.Category)
                    .Include(p => p.Shop)
                    .Take(8).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static Product GetProductByProductIdAndShopId(int productId, int shopId)
        {
            var product = new Product();
            try
            {
                using var context = new BirdTradingPlatformContext();
                product = context.Products.FirstOrDefault(p => p.ProductId == productId && p.ShopId == shopId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
<<<<<<< Updated upstream

        public static List<Product> GetAllProductsByShopId(int shopId)
        {
            var products = new List<Product>();
            try
            {
                using var context = new BirdTradingPlatformContext();
                products = context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Shop)
                    .Where(p => p.ShopId == shopId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
=======
>>>>>>> Stashed changes
    }
}