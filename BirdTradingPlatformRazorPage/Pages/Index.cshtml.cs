using BussinessObject.Enum;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult OnGet()
        {
            Categories = _categoryRepository.GetCategories();
            Products = _productRepository.GetTop8Products();
            return Page();
        }
    }
}
