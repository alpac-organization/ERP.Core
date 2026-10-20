using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class InventoryEntry : BaseEntity<Guid>
    {
        public string? Code { get; set; }
        public string? Observations { get; set; }
        
        public EntryType EntryType { get; set; }
        public EntryStatus EntryStatus { get; set; }
        public string? AdditionalData { get; set; } = "{}";

        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;

        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;

        public Guid? PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; } = default!;

        public virtual ICollection<InventoryEntryItem> InventoryEntryItems { get; set; } = default!;
    }

    public class InventoryEntryAdditionalData
    {
        public List<EntryEvidenceImage> EvidenceImages { get; set; } = [];
    }

    public class EntryEvidenceImage
    {
        public Guid ImageId { get; set; }
        public string? ImageUrl { get; set; }
    }
}