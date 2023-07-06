using BussinessObject.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IShopRepository
    {
        ShopDTO GetShopByAccountId(int accountId);
        ShopDTO GetShopById(int id);

        bool AddNewShop(ShopDTO shop);
    }
}