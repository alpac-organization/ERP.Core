using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Clients
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
    }
}