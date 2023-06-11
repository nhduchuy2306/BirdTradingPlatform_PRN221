using BussinessObject.utils;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public PaginatedList<ProductDTO> PaginatedProducts { get; set; }
        public List<ProductDTO> Top3LatestProducts { get; set; }
        public CategoryDTO Category { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string BirdColor { get; set; }
        public string Country { get; set; }

        public IActionResult OnGet(int? pageIndex, int? categoryId, int? minPrice, int? maxPrice, string color, string country)
        {
            Products = _productRepository.GetProducts();
            Categories = _categoryRepository.GetCategories();
            Top3LatestProducts = _productRepository.GetTop3Products();
            Category = _categoryRepository.GetCategoryById(categoryId ?? 1);
            MinPrice = minPrice ?? 0;
            MaxPrice = maxPrice ?? 100000000;
            BirdColor = color ?? "";
            Country = country ?? "";

            IQueryable<ProductDTO> productsIQ = Products.AsQueryable();

            if (categoryId != null)
            {
                productsIQ = productsIQ.Where(p => p.CategoryId == categoryId);
            }

            if (minPrice != null)
            {
                productsIQ = productsIQ.Where(p => p.UnitPrice >= minPrice);
            }

            if (maxPrice != null)
            {
                productsIQ = productsIQ.Where(p => p.UnitPrice <= maxPrice);
            }

            if (color != null)
            {
                productsIQ = productsIQ.Where(p => p.Color.ToUpper().Trim() == color.ToUpper().Trim());
            }

            if (country != null)
            {
                productsIQ = productsIQ.Where(p => p.MadeIn.ToUpper().Trim() == country.ToUpper().Trim());
            }

            int pageSize = 3;
            PaginatedProducts = PaginatedList<ProductDTO>.Create(productsIQ, pageIndex ?? 1, pageSize);

            return Page();
        }
    }
}
