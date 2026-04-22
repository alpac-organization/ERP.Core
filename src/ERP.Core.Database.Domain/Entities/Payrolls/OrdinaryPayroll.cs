using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class OrdinaryPayroll : BaseEntity<Guid>
    {
        public decimal Ir { get; set; }
        public decimal Inss { get; set; }
        public decimal TotalLegalDeductions { get; set; }


        public decimal Bonus { get; set; }
        public decimal Overtime { get; set; }
        public decimal BiweeklySalary { get; set; } //Salario Quincenal sin deducciones
        public decimal GrossSalary { get; set; } //Donde le sumamos horas extras y bonos


        //Prestamos etc...
        public decimal Deductions { get; set; }

        public decimal TotalDeducctions { get; set; }

        public decimal TotalToPay { get; set; }

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = null!;
        
        public Guid CollaboratorId { get; set;}
        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}