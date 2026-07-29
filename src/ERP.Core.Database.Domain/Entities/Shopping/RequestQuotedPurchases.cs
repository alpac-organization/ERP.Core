using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class RequestQuotedPurchases : BaseEntity<Guid>
    {
        public Guid PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; } = default!;

        public Guid QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; }  = default!;
    }
}