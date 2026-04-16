using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class OrdinaryPayroll : BaseEntity<Guid>
    {
        public decimal Ir { get; set; }
        public decimal Inss { get; set; }
        public decimal Bonus { get; set; }
        public decimal Overtime { get; set; }
        public decimal Deductions { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Vacations { get; set; }
        public decimal TotalToPay { get; set; }
        public decimal TotalDeducctions { get; set; }

        //Relación con la entidad colaborador para axeceder a su información.

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = null!;
        
        public Guid CollaboratorId { get; set;}
        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}