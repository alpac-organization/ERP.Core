using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class UnitMeasure : BaseEntity<Guid>
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
        public string? Description { get; set; }

        public UnitMeasureType Type { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<Product> Products { get; set; } = [];
        public virtual ICollection<ProductStock> ProductStocks { get; set; } = [];
        public virtual ICollection<PurchaseRequestItem> PurchaseRequestItems { get; set; } = [];
        public virtual ICollection<CategoryAllowedUnitMeasures> CategoryAllowedUnitMeasures { get; set; } = [];
    }
}