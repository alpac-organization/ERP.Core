using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class SupplierDetails : BaseEntity<Guid>
    {
        public string? Address { get; set; }
        public string? EmailSupport { get; set; }

        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhoneNumber { get; set; }

        public int CreditDays { get; set; }
        public bool HasCredit { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;
    } 
}