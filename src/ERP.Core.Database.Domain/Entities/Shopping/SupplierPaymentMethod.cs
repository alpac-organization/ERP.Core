using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class SupplierPaymentMethod : BaseEntity<Guid>
    {
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;

        public PaymentMethodType PaymentMethodType { get; set; }

        public bool IsActive { get; set; } = true;

        public string? Notes { get; set; }
    }
}