using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class InventoryAllowedCategories : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }

        public Guid CategoryId { get; set; }
        public virtual CategoryProducts CategoryProducts { get; set; } = default!;
    }
}