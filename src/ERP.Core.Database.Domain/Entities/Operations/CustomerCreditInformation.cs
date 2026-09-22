using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    /// <summary>
    /// Informacion crediticia de una sucursal de cliente.
    /// </summary>
    public class CustomerCreditInformation : BaseEntity<Guid>
    {
        public int CreditDays { get; set; }
        public decimal MaxBalance { get; set; }
        public PaymentCondition PaymentCondition { get; set; }
        public Currency Currency { get; set; }
        public CreditStatus CreditStatus { get; set; }

        public Guid BranchId { get; set; }
        public virtual CustomerBranch Branch { get; set; } = default!;
    }
}