using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Repository.Interface;
using DTO;
using Microsoft.AspNetCore.Http;

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.ProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IShopRepository _shopRepository;

        public IndexModel(IProductRepository productRepository, IShopRepository shopRepository)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
        }

        public List<ProductDTO> productDTOs { get;set; }

        public IActionResult OnGet()
        {
            string shopId = HttpContext.Session.GetString("ShopId");

            if(shopId == null)
            {
                  return RedirectToPage("/Login");
            }

            productDTOs = _productRepository.GetAllProductsByShopId(int.Parse(shopId));
            return Page();
        }
    }
}
