using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            List<Category> list = new List<Category>();
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    list = context.Categories.ToList();
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static Category GetCategoryById(int id)
        {
            Category category = new Category();
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public void AddCategory(Category category)
        {
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCategory(Category category)
        {
            try
            {
                using (var context = new BirdTradingPlatformContext())
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
