using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class ProductStock : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public decimal MinimumStock { get; set; }
        public decimal? MaximumStock { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal WeightedAverageCost { get; set; }

        public ProductStockStatus Status { get; set; }

        public Guid UnitMeasureId { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; } = default!;

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;

        public virtual ICollection<SupplyRequestItem> SupplyRequestItems { get; set; } = [];
        public virtual ICollection<FuelRequest> FuelRequests { get; set; } = [];
        public virtual ICollection<InventoryOutputsItem> InventoryOutputsItems { get; set; } = [];
    }
}