using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class IncomeTaxAccrual : BaseEntity<Guid>
    {
        //Acumulados para el calculo de nomina
        public decimal SalaryEarned { get; set; }
        public decimal AccumulatedIR { get; set; }
        public decimal? AccumulatedSeniority { get; set; }

        public decimal IrMonthly { get; set; }
        public decimal IrFortnight { get; set; }
        public decimal SalaryEarnedMonthly { get; set; }
        public decimal SalaryEarnedFortnight { get; set; }
        //Valor que tomamos para el siguiente periodo de nomina
        public decimal? FlagSalaryEarned { get; set; }
        public decimal? FlagAccumulatedIR { get; set; }


        //Quincena a evaluar por periodos
        public int NumberOfFortnights { get; set; }
        public int? FlagNumberOfFortnights { get; set; }

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;
    }
}