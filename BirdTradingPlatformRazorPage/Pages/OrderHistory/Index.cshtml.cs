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
    public class IndexModel : PageModel
    {
        private readonly BussinessObject.Models.BirdTradingPlatformContext _context;

        public IndexModel(BussinessObject.Models.BirdTradingPlatformContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.OrderParent)
                .Include(o => o.PaymentMethod).ToListAsync();
        }
    }
}
