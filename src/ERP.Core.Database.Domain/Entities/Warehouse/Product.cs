using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class Product : BaseEntity<Guid>
    {
        public string Code {get; set;} = string.Empty;
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public bool IsTaxExempt { get; set;} = false; 

        public Guid CategoryId { get; set; }
        public virtual CategoryProducts Category { get; set; } = default!;

        public Guid UnitMeasureId { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; } = default!;


        public ProductUsageType ProductUsageType { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; } = [];
        public virtual ICollection<PurchaseRequestItem> PurchaseRequestItems { get; set; } = [];
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = [];

        //Inventario
        public virtual ICollection<Kardex> Kardices { get; set; } = [];
    }
}
