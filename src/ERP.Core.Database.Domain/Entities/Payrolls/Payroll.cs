using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Payroll : BaseEntity<Guid>
    {
        public PayrollType PayrollType { get; set; }
        public PayrollStatus Status { get; set; }
        public PayrollPeriod Period { get; set; }

        public DateOnly EndDate { get; set; }
        public DateOnly StartDate { get; set; }


        //Sucursal asociada.
        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = null!;


        //Solicitudes realizadas el durante el proceso de nomina, (Vacacaciones, Citas Medicas, Pagos de vacaciones, etc..)
        public virtual ICollection<PermitApplication> PermitApplications { get; set; } = [];

        // Sub divisiones de nominas.
        public virtual ICollection<OrdinaryPayroll> OrdinaryPayrolls { get; set; } = [];

        
        //Reporteria de los periodos de nominas
        public virtual ICollection<VacationAccrual> VacationAccruals { get; set; } = [];

        //Acumulados de ir y acumulados devengados
        public virtual ICollection<IncomeTaxAccrual> IncomeTaxAccruals { get; set; } = []; 
        public virtual ICollection<ChristmasBonusAccrual> ChristmasBonusAccruals { get; set; } = [];
        public virtual ICollection<InssAccountingInformation> InssAccountingInformation { get; set; } = [];
        public virtual ICollection<RecordsTravelExpensePayments> RecordsTravelExpensePayments { get; set; } = [];
    }
}