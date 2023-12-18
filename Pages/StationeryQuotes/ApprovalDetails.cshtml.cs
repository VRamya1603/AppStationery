using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppStationery.Model;

namespace AppStationery.Pages_StationeryQuotes
{
    public class ApprovalDetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ApprovalDetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public ApprovalViewModel ApprovalDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationeryQuote = await _context.StationeryQuote
                .Include(s => s.ApprovedBy)
                .Include(s => s.Branch)
                .Include(s => s.PrintingStationery)
                .FirstOrDefaultAsync(m => m.StationeryQuoteId == id);

            if (stationeryQuote == null)
            {
                return NotFound();
            }

            ApprovalDetails = new ApprovalViewModel
            {
                PrintingStationery = stationeryQuote.PrintingStationery.Name,
                ApprovedBy = stationeryQuote.ApprovedBy?.UserName,
                Tenant = stationeryQuote.TenantId,
                Branch = stationeryQuote.Branch?.BranchName
            };

            return Page();
        }
    }
}

public class ApprovalViewModel
{
        public string PrintingStationery { get; set; }
        public string ApprovedBy { get; set; }
        public string Tenant { get; set; }
        public string Branch { get; set; }
        public DateTime ApprovedOn { get; set; }
}