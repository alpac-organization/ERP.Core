using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class InventoryAreasPermissions : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;
    }
}