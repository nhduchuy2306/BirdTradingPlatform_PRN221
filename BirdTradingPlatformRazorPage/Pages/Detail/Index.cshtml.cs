using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;
using System.Collections.Generic;

namespace BirdTradingPlatformRazorPage.Pages.Detail
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IShopRepository _shopRepository;

        public IndexModel(
            IProductRepository productRepository, 
            IProductImageRepository productImageRepository, 
            IShopRepository shopRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _shopRepository = shopRepository;
        }

        public ProductDTO productDTO { get; set; }
        public ShopDTO shopDTO { get; set; }
        public List<ProductImageDTO> productImageDTOs { get; set; }
        public List<ProductDTO> relatedProducts { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return RedirectToPage("/Index");

            productDTO = _productRepository.GetProductById((int)id);
            shopDTO = _shopRepository.GetShopById((int)productDTO.ShopId);
            productImageDTOs = _productImageRepository.GetProductImagesByProductId((int)id);
            relatedProducts = _productRepository.GetActiveProductsByShopId((int)productDTO.ShopId);
            return Page();
        }

        public IActionResult OnPostAddToCart(int id, int quantity)
        {
            Console.WriteLine("quantity: " + quantity);
            Console.WriteLine("id: " + id);
            // Todo: Add to cart
            return Redirect(Request.Path + Request.QueryString);
        }

        public IActionResult OnPostRelateAddToCart(int id, int quantity)
        {
            Console.WriteLine("quantity: " + quantity);
            Console.WriteLine("id: " + id);

            return Redirect(Request.Path + Request.QueryString);
        }
    }
}
