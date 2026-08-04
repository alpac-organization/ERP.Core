using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class Quotation : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public DateOnly QuoteDate { get; set; }
        public string? Observations { get; set; }
        public string? QuotationCode { get; set;}
        
        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;

        // public Guid CreatedByUserId { get; set; }
        // public virtual User User { get; set; } = default!;

        public virtual ICollection<QuotedProduct> QuotedProducts { get; set; } = [];
        public virtual ICollection<RequestQuotedPurchases> RequestQuotedPurchases { get; set; } = [];
    }
}
