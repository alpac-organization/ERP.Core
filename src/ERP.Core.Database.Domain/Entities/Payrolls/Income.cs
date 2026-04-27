using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Income : BaseEntity<Guid>
    {
        public decimal AmountInLocal { get; set; }
        public decimal AmountInDollars { get; set; }
        public string? Description { get; set; }
        public Currency Currency { get; set; } = Currency.NIO;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;

        public Guid IncomeTypeId { get; set; }
        public virtual TypesIncome TypesIncome { get; set; } = default!;

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;

    }
}