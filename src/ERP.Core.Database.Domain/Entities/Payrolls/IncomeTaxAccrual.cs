using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class IncomeTaxAccrual : BaseEntity<Guid>
    {
        public decimal SalaryEarned { get; set; }
        public decimal AccumulatedIR { get; set; }
        public int NumberOfFortnights { get; set; }
        public DateTime RegisterDate { get; set; }

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;
    }
}