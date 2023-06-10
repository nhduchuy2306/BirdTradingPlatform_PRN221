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
                products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static Product GetProductById(int id)
        {
            var product = new Product();
            try
            {
                using var context = new BirdTradingPlatformContext();
                product = context.Products.FirstOrDefault(p => p.ProductId == id);
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
    }
}