using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Domain.Entities.Bases
{
    public class BasePayrollEntity: BaseEntity<Guid>
    {
        public decimal Ir { get; set; }
        public decimal Inss { get; set; }
        public decimal TotalLegalDeductions { get; set; }


        public decimal TotalToPay { get; set; } // Total a recibir.



        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = null!;
        
        public Guid CollaboratorId { get; set;}
        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}