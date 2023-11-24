using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppStationery.Model;

namespace AppStationery.Pages_PrintingStationeries
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public PrintingStationery PrintingStationery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PrintingStationery = await _context.PrintingStationery.FirstOrDefaultAsync(m => m.PrintingStationeryId == id);

            if (PrintingStationery == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
