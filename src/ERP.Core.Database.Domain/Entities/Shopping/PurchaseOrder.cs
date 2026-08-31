
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class PurchaseOrder : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        
        public string? Comments { get; set; }
        public DateOnly SentToReviewAt { get; set; }

        public Guid SentByUserId { get; set; }
        public virtual User SentByUser { get; set; } = default!;

        public Guid? ReviewedByUserId { get; set; }
        public virtual User? ReviewedByUser { get; set; }

        public Guid PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; } = default!;
    }
}
