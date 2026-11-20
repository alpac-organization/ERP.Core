using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class PurchaseOrder : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Code { get; set; }
        public PurchaseOrderStatus Status { get; set; }
        
        public Guid? SupplierId { get; set; }
        public virtual Supplier? Supplier { get; set; }

        public string? Comments { get; set; }
        public DateOnly SentToReviewAt { get; set; }

        public Guid SentByUserId { get; set; }
        public virtual User SentByUser { get; set; } = default!;

        public Guid? ReviewedByUserId { get; set; }
        public virtual User? ReviewedByUser { get; set; }

        public Guid PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; } = default!;

        public virtual PaymentRequest? PaymentRequest { get; set; }
        public virtual InventoryEntry? InventoryEntry { get; set; }
        
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = [];
    }
}

