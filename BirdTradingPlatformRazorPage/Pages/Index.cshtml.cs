using BussinessObject.Enum;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BirdTradingPlatformRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public IndexModel(ICategoryRepository categoryRepository, IProductRepository productRepository, 
            IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public List<CategoryDTO> Categories { get; set; }
        public List<ProductDTO> Products { get; set; }
        public string currentUrl { get; set; }

        public IActionResult OnGet()
        {
            Categories = _categoryRepository.GetCategories();
            Products = _productRepository.GetTop8Products();
            currentUrl = HttpContext.Request.GetDisplayUrl();

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

                CartItemDTO existingCartItemDTO = cartItemDTOs.SingleOrDefault(c => c.ProductId == productId);

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
