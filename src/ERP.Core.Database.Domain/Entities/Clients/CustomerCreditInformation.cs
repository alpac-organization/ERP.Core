using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Clients
{
    /// <summary>
    /// Informacion crediticia de una sucursal de cliente.
    /// </summary>
    public class CustomerCreditInformation : BaseEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public int CreditDays { get; set; }
        public decimal MaxBalance { get; set; }
        public PaymentCondition PaymentCondition { get; set; }      // credit || cash
        public Currency Currency { get; set; }                      // Nio || Usd
        public CreditStatus CreditStatus { get; set; }

        public Guid BranchId { get; set; }

        public virtual Branch Branch { get; set; } = default!;
        public virtual Customers Customer { get; set; } = default!;
    }
}