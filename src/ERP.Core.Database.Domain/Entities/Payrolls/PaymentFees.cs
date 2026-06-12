using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    //Tarifas de pagos por empresas
    public class PaymentFees : BaseEntity<Guid>
    {
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        public Currency Currency { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;
    }
}   