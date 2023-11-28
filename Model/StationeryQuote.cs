using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Finbuckle.MultiTenant;

namespace AppStationery.Model
{
    public enum ApprovalState
    {
        Pending,
        Approved,
        Rejected
    }

    [MultiTenant]
    public class StationeryQuote
    {
        public int StationeryQuoteId { get; set; }

        public int PrintingStationeryId { get; set; }
        public PrintingStationery? PrintingStationery { get; set; }

        public string? QuoteNo { get; set; }
        public string? ReferenceNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Quoted On")]
        public DateTime QuotedOn { get; set; } = DateTime.UtcNow;

        public decimal? QuotePerCopyPrice { get; set; }
        public decimal? QuotePerBookPrice { get; set; }

        public decimal? ApprovedPerCopyPrice { get; set; }
        public decimal? ApprovedPerBookPrice { get; set; }

        public decimal? MinmumOrderQuantity { get; set; }

        [Display(Name = "Branch")]
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }

        [Display(Name = "Tenant")]
        public string? TenantId { get; set; }

        [Display(Name = "Approval State")]
        public ApprovalState ApprovalState { get; set; }

        [Display(Name = "Approved By")]
        public int? ApprovedById { get; set; }
        [Display(Name = "Approved By")]
        public ApplicationUser? ApprovedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Approved On")]
        public DateTime? ApprovedOn { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Comments { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
    
