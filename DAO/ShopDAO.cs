using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ShopDAO
    {
        public static Shop GetShopById(int id)
        {
            Shop shop = new Shop();
            try
            {
                using var context = new BirdTradingPlatformContext();
                shop = context.Shops.FirstOrDefault(s => s.ShopId == id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return shop;
        }
    }
}