using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppStationery.Model;

namespace AppStationery.Pages_StationeryQuotes
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApprovedById"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "UserName");
        ViewData["BranchId"] = new SelectList(_context.Set<Branch>(), "BranchId", "BranchName");
        ViewData["PrintingStationeryId"] = new SelectList(_context.PrintingStationery, "PrintingStationeryId", "Name");
            return Page();
        }

        [BindProperty]
        public StationeryQuote StationeryQuote { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StationeryQuote.Add(StationeryQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
