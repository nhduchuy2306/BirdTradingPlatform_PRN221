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
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public DeleteModel(IProductRepository productRepository, IShopRepository shopRepository, ICategoryRepository categoryRepository, IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
            _categoryRepository = categoryRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public ProductDTO productDTO { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            productDTO = _productRepository.GetProductById(id.Value);

            if (productDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool isExist = _orderDetailRepository.CheckIsExistProductInOrderDetail(id.Value);
            if (!isExist)
            {
                productDTO = _productRepository.GetProductById(id.Value);

                if (productDTO != null)
                {
                    _productRepository.DeleteProduct(productDTO);
                }

                string alertMessage = "Delete Successfull";
                return Redirect($"/ShopManagement/ProductManagement?alertMessage={Uri.EscapeDataString(alertMessage)}");
            }
            else
            {
                /*  ViewData["Error"] = "Product exist in order detail, cannot delete!!";
                  return Page();*/

                string alertMessage = "Product exist in order detail, cannot delete!!";
                return Redirect($"/ShopManagement/ProductManagement?alertMessage={Uri.EscapeDataString(alertMessage)}");
            }
        }
    }
}
