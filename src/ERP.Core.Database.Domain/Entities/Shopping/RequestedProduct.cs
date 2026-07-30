using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class RequestedProduct : BaseEntity<Guid>
    {
        public int Quantity { get; set; }
        public int? QuantityUnit { get; set; }

        public string? Justification { get; set; }

        public Guid UnitMeasureId { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; } = default!;

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        public Guid PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; } = default!;
    }
}