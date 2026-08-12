using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class RequisitionAccountingReview : BaseEntity<Guid>
    {
        public string? Comments { get; set; }
        public DateOnly SentToReviewAt  { get; set; }

        public AccountingReviewStatus Status { get; set; } = AccountingReviewStatus.Pending;

        public Guid SentByUserId { get; set; }
        public virtual User SentByUser { get; set; } = default!;
        
        public Guid? ReviewedByUserId { get; set; }
        public virtual User? ReviewedByUser { get; set; }

        public Guid PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; } = default!;
    }
}
