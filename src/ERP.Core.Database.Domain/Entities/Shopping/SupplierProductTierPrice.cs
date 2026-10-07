using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    // Entidad para Precio preferencial por volumen de items con un vínculo proveedor–producto.
    public class SupplierProductTierPrice : BaseEntity<Guid>
    {
        // la Cantidad mínima a partir de la cual aplica el precio preferencial.
        public int MinQuantity { get; set; }

        public DateOnly ValidFrom { get; set; }

        // esta la Fecha de fin de vigencia. en Null = sin fecha de fin.
        public DateOnly? ValidTo { get; set; }

        public decimal PreferentialPrice { get; set; }

        public Guid SupplierProductId { get; set; }
        public virtual SupplierProduct SupplierProduct { get; set; } = default!;

        public Guid? UnitMeasureId { get; set; }
        public virtual UnitMeasure? UnitMeasure { get; set; }
    }
}
