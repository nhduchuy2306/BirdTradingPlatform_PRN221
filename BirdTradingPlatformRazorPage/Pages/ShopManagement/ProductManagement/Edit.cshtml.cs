using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Repository.Interface;
using DTO;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using BussinessObject.Enum;

namespace BirdTradingPlatformRazorPage.Pages.ShopManagement.ProductManagement
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IShopRepository _shopRepository;

        public EditModel(IProductRepository productRepository, IShopRepository shopRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
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
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetCategories(), "CategoryId", "CategoryName");
            return Page();
        }

        public IActionResult OnPost()
        {
            int shopId;
            string shop = HttpContext.Session.GetString("ShopId");

            if (shop == null)
            {
                return RedirectToPage("/Login");
            }
            else { shopId = int.Parse(HttpContext.Session.GetString("ShopId")); }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
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

                productDTO.ShopId = shopId;
                productDTO.Status = ProductEnum.INACTIVE.ToString();
                productDTO.Rating = 0;
                productDTO.CreateDate = DateTime.Now;
                _productRepository.UpdateProduct(productDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(productDTO.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _productRepository.GetProductById(id) != null;
        }
    }
}
