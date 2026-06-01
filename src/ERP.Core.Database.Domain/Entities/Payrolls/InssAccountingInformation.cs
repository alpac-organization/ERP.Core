using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class InssAccountingInformation : BaseEntity<Guid>
    {
        public decimal Total { get; set; }
        public decimal Inatec { get; set; }
        public decimal InssLabor { get; set; }
        public decimal InssPatronal { get; set; }

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;
    }
}