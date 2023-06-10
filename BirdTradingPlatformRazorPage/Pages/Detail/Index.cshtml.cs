using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdTradingPlatformRazorPage.Pages.Detail
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDTO productDTO { get; set; }

        public IActionResult OnGet(int id)
        {
            productDTO = _productRepository.GetProductById(id);
            return Page();
        }
    }
}
