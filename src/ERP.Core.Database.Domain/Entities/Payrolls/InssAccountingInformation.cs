using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{

    //✅Información del inss para reportes contables.
    public class InssAccountingInformation : BaseEntity<Guid>
    {
        public decimal Total { get; set; }
        public decimal Inatec { get; set; }
        public decimal Absence { get; set; }
        public decimal InssLabor { get; set; }
        public decimal InssPatronal { get; set; }
        public decimal Income { get; set; }
        public int DaysAbsence { get; set; }

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;
    }
}