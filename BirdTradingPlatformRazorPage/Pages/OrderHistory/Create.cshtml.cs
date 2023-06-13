using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Models;

namespace BirdTradingPlatformRazorPage.Pages.OrderHistory
{
    public class CreateModel : PageModel
    {
        private readonly BussinessObject.Models.BirdTradingPlatformContext _context;

        public CreateModel(BussinessObject.Models.BirdTradingPlatformContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrderParentId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
        ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "PaymentMethodId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
