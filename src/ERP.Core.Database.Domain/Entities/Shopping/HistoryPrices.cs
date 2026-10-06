using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    // Historial de precios del vínculo proveedor–producto (unitario o preferencial).
    public class HistoryPrices : BaseEntity<Guid>
    {
        public SupplierPriceHistoryType PriceType { get; set; }

        // el Precio que dejó de ser vigente.
        public decimal Price { get; set; }

        /// Umbral de volumen asociado (aqui esto solo para PreferentialPrice).
        public int? MinQuantity { get; set; }

        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }

        public Guid SupplierProductId { get; set; }
        public virtual SupplierProduct SupplierProduct { get; set; } = default!;
    }
}
