using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;

namespace BirdTradingPlatformRazorPage.Pages.OrderHistory
{
    public class DetailsModel : PageModel
    {
        private readonly BussinessObject.Models.BirdTradingPlatformContext _context;

        public DetailsModel(BussinessObject.Models.BirdTradingPlatformContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.OrderParent)
                .Include(o => o.PaymentMethod).FirstOrDefaultAsync(m => m.OrderId == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
