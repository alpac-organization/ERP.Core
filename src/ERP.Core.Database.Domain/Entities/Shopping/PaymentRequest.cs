using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    // Solicitud de pago asociada 1:1 a una orden de compra.
    public class PaymentRequest : BaseEntity<Guid>
    {
        public string Code { get; set; } = string.Empty;

        public PaymentMethodType PaymentMethodType { get; set; }

        public Guid PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; } = default!;
    }
}
