using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Models;
using DTO;
using Repository.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Http;
using BussinessObject.Enum;

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IShopRepository _shopRepository;

        public CreateModel(IProductRepository productRepository, IShopRepository shopRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
        public ProductDTO productDTO { get; set; }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetCategories(), "CategoryId", "CategoryName");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int shopId = int.Parse(HttpContext.Session.GetString("ShopId"));
            productDTO.ShopId = shopId;
            productDTO.Status = ProductEnum.INACTIVE.ToString();
            productDTO.Rating = 0;
            productDTO.CreateDate = DateTime.Now;

            _productRepository.AddProduct(productDTO);

            return RedirectToPage("./Index");
        }
    }
}
