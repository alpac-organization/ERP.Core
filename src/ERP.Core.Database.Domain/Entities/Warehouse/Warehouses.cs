using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class Warehouses : BaseEntity<Guid>
    {
        public string? Code { get; set; }
        public bool IsActive { get; set; } = true;
        public WarehouseType WarehouseType { get; set; }

        public virtual WarehouseLocation WarehouseLocation { get; set; } = null!;
        public virtual WarehouseCapacity WarehouseCapacity { get; set; } = null!;

        public virtual ICollection<Sections> Sections { get; set; } = [];
    }
}