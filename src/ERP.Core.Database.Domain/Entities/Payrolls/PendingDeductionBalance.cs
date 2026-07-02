using ERP.Core.Database.Domain.Entities.Bases;
namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class PendingDeductionBalance : BaseEntity<Guid>
    {
        public Guid CollaboratorId { get; set; }

        public virtual Collaborator Collaborator { get; set; } = null!;

        public Guid OriginPayrollId { get; set; }

        public virtual Payroll OriginPayroll { get; set; } = null!;

        public Guid DeductionId { get; set; }

        public virtual Deduction Deduction { get; set; } = null!;

        public decimal AmountOwed { get; set; }

        public string? Reason { get; set; }

        public bool IsRecovered { get; set; }
    }
}