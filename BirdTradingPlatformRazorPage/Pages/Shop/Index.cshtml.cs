using BussinessObject.utils;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

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

        public string currentUrl { get; set; }

        public IActionResult OnGet(int? pageIndex, int? categoryId, int? minPrice, int? maxPrice, string color)
        {
            currentUrl = HttpContext.Request.GetDisplayUrl();

            Products = _productRepository.GetProducts();
            Categories = _categoryRepository.GetCategories();
            Top3LatestProducts = _productRepository.GetTop3Products();
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

        public IActionResult OnGetAddToCart(int productId)
        {
            ProductDTO productDTO = _productRepository.GetProductById(productId);

            CartItemDTO cartItemDTO = new CartItemDTO
            {
                ProductId = productDTO.ProductId,
                ProductName = productDTO.ProductName,
                UnitPrice = productDTO.UnitPrice ?? 0,
                Quantity = 1,
                ProductImage = productDTO.ProductImage,
                ShopName = productDTO.ShopName,
                ShopId = productDTO.ShopId ?? 0
            };

            string cart = HttpContext.Session.GetString("cart");

            if (string.IsNullOrEmpty(cart))
            {
                List<CartItemDTO> cartItemDTOs = new List<CartItemDTO>
                {
                    cartItemDTO
                };

                string jsonCart = JsonSerializer.Serialize(cartItemDTOs);
                HttpContext.Session.SetString("cart", jsonCart);
            }
            else
            {
                List<CartItemDTO> cartItemDTOs = JsonSerializer.Deserialize<List<CartItemDTO>>(cart);

                CartItemDTO existingCartItemDTO = cartItemDTOs.FirstOrDefault(c => c.ProductId == productId);

                if (existingCartItemDTO == null)
                {
                    cartItemDTOs.Add(cartItemDTO);
                }
                else
                {
                    existingCartItemDTO.Quantity++;
                }

                string jsonCart = JsonSerializer.Serialize(cartItemDTOs);
                HttpContext.Session.SetString("cart", jsonCart);
            }

            return RedirectToPage(currentUrl);
        }
    }
}
