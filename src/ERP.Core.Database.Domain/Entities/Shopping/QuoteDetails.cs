using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class QuoteDetail : BaseEntity<Guid>
    {
        public QuotationStatus Status { get; set; }
        public decimal ApproximateTotalCost { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;

        public Guid QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; } = default!;

        public virtual ICollection<QuotedProduct> QuotedProducts { get; set; } = [];
    }
}
