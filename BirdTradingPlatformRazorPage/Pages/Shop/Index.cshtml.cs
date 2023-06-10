using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;
using System.Collections.Generic;

namespace BirdTradingPlatformRazorPage.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public IndexModel(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public List<ProductDTO> Products { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<ProductDTO> Top3LatestProducts { get; set; }

        public IActionResult OnGet()
        {
            Products = _productRepository.GetProducts();
            Categories = _categoryRepository.GetCategories();
            Top3LatestProducts = _productRepository.GetTop3Products();
            return Page();
        }

        public IActionResult OnGetShowProductByCategory(int id)
        {
            Products = _productRepository.GetProductByCategoryId(id);
            Categories = _categoryRepository.GetCategories();
            Top3LatestProducts = _productRepository.GetTop3Products();
            return Page();
        }
    }
}
