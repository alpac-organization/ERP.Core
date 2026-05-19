using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class VacationAccrual : BaseEntity<Guid>
    {
        public decimal AvailableVacations { get; set; }
        public decimal EquivalentQuantity { get; set; }
        public decimal EquivalentQuantityInDollars { get; set; }

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;
    }
}
