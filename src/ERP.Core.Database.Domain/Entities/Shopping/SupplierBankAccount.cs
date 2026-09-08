using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class SupplierBankAccount : BaseEntity<Guid>
    {
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;
        public string BankName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public BankAccountType AccountType { get; set; }
        public Currency Currency { get; set; }
        public string AccountHolderName { get; set; } = string.Empty;
        public string? AccountHolderIdentification { get; set; }
        public bool IsPrimary { get; set; } = false;
    }
}