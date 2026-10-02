using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    /// entidad proveedor–producto
    public class SupplierProduct : BaseEntity<Guid>
    {
        public bool IsActive { get; set; } = true;

        // este es el Precio unitario vigente de este proveedor para este producto.
        public decimal UnitPrice { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;

        public virtual ICollection<HistoryPrices> PriceHistories { get; set; } = [];
    }
}
