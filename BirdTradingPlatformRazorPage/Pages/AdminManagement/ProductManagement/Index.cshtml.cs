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

namespace BirdTradingPlatformRazorPage.Pages.AdminManagement.ProductManagement
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
        public CategoryDTO Category { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string BirdColor { get; set; }

        public string currentUrl { get; set; }

        public IActionResult OnGet(int? pageIndex, int? categoryId, int? minPrice, int? maxPrice, string color)
        {
            string staffId = HttpContext.Session.GetString("StaffId");

            if (staffId == null)
            {
                return RedirectToPage("/Login");
            }

            currentUrl = HttpContext.Request.GetDisplayUrl();

            Products = _productRepository.GetAllProductsInactive();
            Categories = _categoryRepository.GetCategories();
            Category = _categoryRepository.GetCategoryById(categoryId ?? 1);
            MinPrice = minPrice ?? 0;
            MaxPrice = maxPrice ?? 1000000;
            BirdColor = color ?? "";

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

            int pageSize = 9;
            PaginatedProducts = PaginatedList<ProductDTO>.Create(productsIQ, pageIndex ?? 1, pageSize);

            return Page();
        }

        public IActionResult OnGetApprove(int productId)
        {
            ProductDTO productDTO = _productRepository.GetProductById(productId);
            return RedirectToPage(currentUrl);
        }

    }
}
