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
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        //public IList<StationeryQuote> StationeryQuote { get;set; }
        public List<StationeryQuoteIndexViewModel> StationeryQuote { get;set; }

        public async Task OnGetAsync()
        {
            StationeryQuote = await _context.StationeryQuote
                //.Include(s => s.ApprovedBy)
                //.Include(s => s.Branch)
                //.Include(s => s.PrintingStationery)
                .Where(s => !s.IsDeleted)
                .Select(s => new StationeryQuoteIndexViewModel
                {
                    StationeryQuoteId = s.StationeryQuoteId,
                    PrintingStationery = s.PrintingStationery.Name,
                    QuoteNo = s.QuoteNo,
                    ReferenceNo = s.ReferenceNo,
                    QuotedOn = s.QuotedOn,
                    QuotePerCopyPrice = s.QuotePerCopyPrice,
                    QuotePerBookPrice = s.QuotePerBookPrice,
                    ApprovedPerCopyPrice = s.ApprovedPerCopyPrice,
                    ApprovedPerBookPrice = s.ApprovedPerBookPrice,
                    MinmumOrderQuantity = s.MinmumOrderQuantity,
                    Branch = s.Branch.BranchName,
                    ApprovedBy = s.ApprovedBy.UserName,
                    IsActive = s.IsActive
                }).ToListAsync();
        }
    }
}

public class StationeryQuoteIndexViewModel
{
    public int StationeryQuoteId {get; set;}
    public string? PrintingStationery { get; set; }
    public string? QuoteNo {get; set;}
    public string? ReferenceNo { get; set; }
    public DateTime QuotedOn { get; set; }
    public decimal? QuotePerCopyPrice { get; set; }
    public decimal? QuotePerBookPrice { get; set; }
    public decimal? ApprovedPerCopyPrice { get; set; }
    public decimal? ApprovedPerBookPrice { get; set; }
    public int? MinmumOrderQuantity { get; set; }
    public string? Branch { get; set;}
    public string? ApprovedBy { get; set; }
    public bool IsActive { get; set; }
}
