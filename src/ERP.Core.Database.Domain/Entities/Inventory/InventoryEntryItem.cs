using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class InventoryEntryItem : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }

        public Guid InventoryEntryId { get; set; }
        public virtual InventoryEntry InventoryEntry { get; set; } = default!;
    }
}