using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Models;
using DTO;
using Repository.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Http;
using BussinessObject.Enum;
using System.Text.RegularExpressions;

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IShopRepository _shopRepository;

        public CreateModel(IProductRepository productRepository, IShopRepository shopRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
        public ProductDTO productDTO { get; set; }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetCategories(), "CategoryId", "CategoryName");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool invalid = false;
            string pattern = @"^\s*$";
            if (productDTO?.ProductName == null || Regex.IsMatch(productDTO.ProductName, pattern))
            {
                ModelState.AddModelError("productDTO.ProductName", "Product Name cannot be empty!");
                invalid = true;
            }

            if (productDTO?.Weight == null)
            {
                ModelState.AddModelError("productDTO.Weight", "Product Weight cannot be empty!");
                invalid = true;
            }

            if (productDTO?.UnitPrice == null)
            {
                ModelState.AddModelError("productDTO.UnitPrice", "Product Price cannot be empty!");
                invalid = true;
            }

            if (productDTO?.Quantity == null)
            {
                ModelState.AddModelError("productDTO.Quantity", "Product Quantity cannot be empty!");
                invalid = true;
            }

            if (productDTO?.Expiration != null && productDTO.Expiration < DateTime.Now.AddDays(7))
            {
                ModelState.AddModelError("productDTO.Expiration", "Expired Date must be at least a week away from current date!");
                invalid = true;
            }

            if (productDTO?.Description == null || Regex.IsMatch(productDTO.Description, pattern))
            {
                ModelState.AddModelError("productDTO.Description", "Description cannot be empty!");
                invalid = true;
            }

            if (productDTO?.ProductImage == null || Regex.IsMatch(productDTO?.ProductImage, pattern))
            {
                ModelState.AddModelError("productDTO.ProductImage", "Product Image cannot be empty!");
                invalid = true;
            }

            if (invalid)
            {
                ViewData["CategoryId"] = new SelectList(_categoryRepository.GetCategories(), "CategoryId", "CategoryName");
                return Page();
            }

            int shopId = int.Parse(HttpContext.Session.GetString("ShopId"));
            productDTO.ShopId = shopId;
            productDTO.Status = ProductEnum.INACTIVE.ToString();
            productDTO.Rating = 0;
            productDTO.CreateDate = DateTime.Now;

            _productRepository.AddProduct(productDTO);

            //return RedirectToPage("./Index");
            string alertMessage = "Product created successfully!";
            return Redirect($"/ShopManagement/ProductManagement?alertMessage={Uri.EscapeDataString(alertMessage)}");
        }
    }
}
