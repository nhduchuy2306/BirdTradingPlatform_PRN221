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

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.ProductManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IProductImageRepository _productImageRepository;

        public DetailsModel(IProductRepository productRepository, IShopRepository shopRepository, ICategoryRepository categoryRepository, IProductImageRepository productImageRepository)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
        }

        public ProductDTO productDTO { get; set; }
        public List<ProductImageDTO> productImages { get; set; }
        public ProductImageDTO productImageDTO { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            productDTO = _productRepository.GetProductById(id.Value);
            productImages = _productImageRepository.GetProductImagesByProductId(id.Value);

            if (productDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAddImageForProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            productImageDTO = new ProductImageDTO();
            productImageDTO.ProductId = id.Value;
            productImageDTO.Status = "Active";
            productImages.Add(productImageDTO);

            return Page();
        }
    }
}
