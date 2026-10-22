using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class ProductStock : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public int MinimumStock { get; set; }
        public int? MaximumStock { get; set; }
        public int AvailableQuantity { get; set; }
        
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;

        public virtual ICollection<SupplyRequestItem> SupplyRequestItems { get; set; } = [];
    }
}