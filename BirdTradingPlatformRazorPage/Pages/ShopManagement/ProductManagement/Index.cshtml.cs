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
using BussinessObject.utils;
using Microsoft.AspNetCore.Http.Extensions;
using System.Drawing;

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.ProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IShopRepository _shopRepository;
        private readonly ICategoryRepository _categoryRepository;

        public IndexModel(IProductRepository productRepository, IShopRepository shopRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
            _categoryRepository = categoryRepository;
        }

        public List<ProductDTO> Products { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public PaginatedList<ProductDTO> PaginatedProducts { get; set; }
        public CategoryDTO Category { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string BirdColor { get; set; }

        public string currentUrl { get; set; }

        [BindProperty]
        public string SearchString { get; set; }

        //public List<ProductDTO> productDTOs { get;set; }

        public IActionResult OnGet(int? pageIndex, int? categoryId, int? minPrice, int? maxPrice, string color, string searchString)
        {
            string shopId = HttpContext.Session.GetString("ShopId");

            if (shopId == null)
            {
                return RedirectToPage("/Login");
            }

            currentUrl = HttpContext.Request.GetDisplayUrl();

            Products = _productRepository.GetAllProductsByShopId(int.Parse(shopId));
            Categories = _categoryRepository.GetCategories();
            Category = _categoryRepository.GetCategoryById(categoryId ?? 1);
            MinPrice = minPrice ?? 0;
            MaxPrice = maxPrice ?? 1000000;
            BirdColor = color ?? "";
            SearchString = searchString;

            IQueryable<ProductDTO> productsIQ = Products.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                productsIQ = productsIQ.Where(x => x.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
                pageIndex = 1;
            }

            if (categoryId != null)
            {
                productsIQ = productsIQ.Where(p => p.CategoryId == categoryId);
            }

            if (minPrice != null)
            {
                int start = minPrice ?? 0;
                productsIQ = productsIQ.Where(p => p.UnitPrice >= start);
            }

            if (maxPrice != null)
            {
                int end = maxPrice ?? 1000000;
                productsIQ = productsIQ.Where(p => p.UnitPrice <= end);
            }

            if (color != null)
            {
                productsIQ = productsIQ.Where(p => p.Color.ToUpper().Trim() == color.ToUpper().Trim());
            }

            int pageSize = 9;
            PaginatedProducts = PaginatedList<ProductDTO>.Create(productsIQ, pageIndex ?? 1, pageSize);

            return Page();
        }
    }
}
