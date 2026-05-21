using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Payroll : BaseEntity<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PayrollStatus Status { get; set; }
        public PayrollType PayrollType { get; set; }

        //Sucursal asociada.
        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = null!;

        // Sub divisiones de nominas.
        public virtual ICollection<OrdinaryPayroll> OrdinaryPayrolls { get; set; } = [];

        // Agregar nomina servicios profesionales.


        //Acumulados de los colaboradores
        public virtual ICollection<VacationAccrual> VacationAccruals { get; set; } = [];
        public virtual ICollection<IncomeTaxAccrual> IncomeTaxAccruals { get; set; } = []; 
        public virtual ICollection<ChristmasBonusAccrual> ChristmasBonusAccruals { get; set; } = [];
        public virtual ICollection<RecordsTravelExpensePayments> RecordsTravelExpensePayments { get; set; } = [];
    }
}