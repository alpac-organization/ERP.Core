using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    //  detalle de una orden de compra.
    public class PurchaseOrderItem : BaseEntity<Guid>
    {
        public int Quantity { get; set; }

        // Precio unitario acordado en la orden 
        public decimal UnitPrice { get; set; }

        public Guid PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; } = default!;

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        // Ítem de la solicitud de origen 
        public Guid? PurchaseRequestItemId { get; set; }
        public virtual PurchaseRequestItem? PurchaseRequestItem { get; set; }
    }
}
