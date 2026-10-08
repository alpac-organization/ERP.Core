using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    // aqui la junction table del Vínculo proveedor–producto con precio unitario vigente.
    public class SupplierProduct : BaseEntity<Guid>
    {
        public bool IsActive { get; set; } = true;

        // Precio unitario vigente de este proveedor para este producto.
        public decimal UnitPrice { get; set; }

        // Fecha en que el precio unitario vigente entró en vigor.
        public DateTime LastPriceUpdate { get; set; }

        public Currency Currency { get; set; } = Currency.NIO;

        public string? ExclusiveStatusComments { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;

        public virtual ICollection<HistoryPrices> PriceHistories { get; set; } = [];
        public virtual ICollection<SupplierProductTierPrice> TierPrices { get; set; } = [];
        public virtual ICollection<Quotation> Quotations { get; set; } = [];
    }
}
