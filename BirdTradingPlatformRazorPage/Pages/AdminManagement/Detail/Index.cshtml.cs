using BussinessObject.Enum;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System;
using System.Collections.Generic;

namespace BirdTradingPlatformRazorPage.Pages.AdminManagement.Detail
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
            relatedProducts = _productRepository.GetProductByShopId((int)productDTO.ShopId);
            return Page();
        }

        public IActionResult OnGetApprove(int id)
        {
            ProductDTO productDTO = _productRepository.GetProductById(id);
            productDTO.Status = ProductEnum.ACTIVE.ToString();
            _productRepository.UpdateProduct(productDTO);
            string alertMessage = "Product approved successfully!";
            return Redirect($"/AdminManagement/ProductManagement?alertMessage={Uri.EscapeDataString(alertMessage)}");
        }

        public IActionResult OnGetDecline(int id)
        {
            ProductDTO productDTO = _productRepository.GetProductById(id);
            _productRepository.DeleteProduct(productDTO);
            string alertMessage = "Product declined successfully!";
            return Redirect($"/AdminManagement/ProductManagement?alertMessage={Uri.EscapeDataString(alertMessage)}");
        }
    }
}
