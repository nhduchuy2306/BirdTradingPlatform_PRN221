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
        public ShopDTO GetShopById(int id);
    }
}