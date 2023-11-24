using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppStationery.Model;

namespace AppStationery.Pages_StationeryQuotes
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ApprovedById"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "UserName");
           ViewData["BranchId"] = new SelectList(_context.Set<Branch>(), "BranchId", "BranchName");
           ViewData["PrintingStationeryId"] = new SelectList(_context.PrintingStationery, "PrintingStationeryId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StationeryQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationeryQuoteExists(StationeryQuote.StationeryQuoteId))
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

        private bool StationeryQuoteExists(int id)
        {
            return _context.StationeryQuote.Any(e => e.StationeryQuoteId == id);
        }
    }
}
