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
        public StationeryQuoteEditViewModel StationeryQuoteEdit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationeryQuote = await _context.StationeryQuote
                //.Include(s => s.ApprovedBy)
                //.Include(s => s.Branch)
                //.Include(s => s.PrintingStationery)
                .FirstOrDefaultAsync(m => m.StationeryQuoteId == id);

            /*var printingStationeryName = await _context.PrintingStationery.Select(p => p.Name).FirstOrDefaultAsync();
            var branchName = await _context.Branch.Select(b => b.BranchName).FirstOrDefaultAsync();*/

            if (stationeryQuote == null)
            {
                return NotFound();
            }

            StationeryQuoteEdit = new StationeryQuoteEditViewModel
            {
                StationeryQuoteId = stationeryQuote.StationeryQuoteId,
                PrintingStationeryName = stationeryQuote.PrintingStationery?.Name,
                QuoteNo = stationeryQuote.QuoteNo,
                ReferenceNo = stationeryQuote.ReferenceNo,
                QuotedOn = DateTime.UtcNow,
                QuotePerCopyPrice = stationeryQuote.QuotePerCopyPrice,
                QuotePerBookPrice = stationeryQuote.QuotePerBookPrice,
                MinmumOrderQuantity = stationeryQuote.MinmumOrderQuantity,
                Branch = stationeryQuote.Branch?.BranchName,
            };

            //ViewData["ApprovedById"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "UserName");
            ViewData["BranchId"] = new SelectList(_context.Set<Branch>(),"BranchId","BranchName");
            ViewData["PrintingStationeryId"] = new SelectList(_context.PrintingStationery,"PrintingStationeryId","Name");
              

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

        var stationeryQuoteToUpdate = await _context.StationeryQuote.FindAsync(StationeryQuoteEdit.StationeryQuoteId);

        if (stationeryQuoteToUpdate == null)
        {
            return NotFound();
        }
            
        stationeryQuoteToUpdate.PrintingStationery = await _context.PrintingStationery.FirstOrDefaultAsync(p => p.Name == StationeryQuoteEdit.PrintingStationeryName);
        //stationeryQuoteToUpdate.PrintingStationery = StationeryQuoteEdit.PrintingStationeryName;
        stationeryQuoteToUpdate.QuoteNo = StationeryQuoteEdit.QuoteNo;
        stationeryQuoteToUpdate.ReferenceNo = StationeryQuoteEdit.ReferenceNo;
        stationeryQuoteToUpdate.QuotedOn = StationeryQuoteEdit.QuotedOn;
        stationeryQuoteToUpdate.QuotePerCopyPrice = StationeryQuoteEdit.QuotePerCopyPrice;
        stationeryQuoteToUpdate.QuotePerBookPrice = StationeryQuoteEdit.QuotePerBookPrice;
        stationeryQuoteToUpdate.MinmumOrderQuantity = StationeryQuoteEdit.MinmumOrderQuantity;
        stationeryQuoteToUpdate.Branch = await _context.Branch.FirstOrDefaultAsync(b => b.BranchName == StationeryQuoteEdit.Branch);
        //stationeryQuoteToUpdate.Branch = StationeryQuoteEdit.Branch;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StationeryQuoteExists(StationeryQuoteEdit.StationeryQuoteId))
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

public class StationeryQuoteEditViewModel
{
    public int StationeryQuoteId {get; set;}
    public string? PrintingStationeryName { get; set; }

    public string QuoteNo {get; set;}
    public string ReferenceNo { get; set; }
    public DateTime QuotedOn { get; set; }
    public decimal? QuotePerCopyPrice { get; set; }
    public decimal? QuotePerBookPrice { get; set; }
    public int? MinmumOrderQuantity { get; set; }
    public string Branch { get; set;}
}

