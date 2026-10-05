using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    // Historial de precios unitarios de un vínculo proveedor–producto.
    public class HistoryPrices : BaseEntity<Guid>
    {
        // Precio unitario que dejó de ser vigente.
        public decimal UnitPrice { get; set; }

        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }

        public Guid SupplierProductId { get; set; }
        public virtual SupplierProduct SupplierProduct { get; set; } = default!;
    }
}
