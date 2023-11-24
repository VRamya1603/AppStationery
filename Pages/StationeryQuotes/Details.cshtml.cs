using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppStationery.Model;

namespace AppStationery.Pages_StationeryQuotes
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public StationeryQuote StationeryQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StationeryQuote = await _context.StationeryQuote
                .Include(s => s.ApprovedBy)
                .Include(s => s.Branch)
                .Include(s => s.PrintingStationery).FirstOrDefaultAsync(m => m.StationeryQuoteId == id);

            if (StationeryQuote == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
