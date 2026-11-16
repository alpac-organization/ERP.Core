using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ChristmasBonusAccrual : BaseEntity<Guid>
    {
        public Guid ChristmasBonusPeriodId { get; set; } // a que periodo esta referenciado
        public virtual ChristmasBonusPeriod ChristmasBonusPeriod { get; set; } = default!;


        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;


        public int AccrualYear { get; set; } //year
        public int AccrualMonth { get; set; } //month

        public DateOnly CoveredFrom { get; set; } //que cobertura como tal tiene el registro
        public DateOnly CoveredTo { get; set; }

        public decimal EligibleDays { get; set; }//Cantidad de días que generaron derecho.

         public decimal ChristmasBonusDays { get; set; } // dias generados aqui

        public decimal BaseSalarySnapshot { get; set; } // hacemos tracking de que salario se utilizo por si cambia en algun momento

        public decimal AccruedAmount { get; set; } // money acumulado

        public decimal? AccruedAmountInDollars { get; set; } //monto en dolares

        public ChristmasBonusAccrualStatus Status { get; set; } 

        public bool IsProjected { get; set; } 

        public int Revision { get; set; } = 1; //cuantas revisiones hubieron

        public ChristmasBonusCalculationReason CalculationReason { get; set; } 

        public bool IsCurrent { get; set; } = true; // flag de que version es la actual

        public Guid? ReplacesAccrualId { get; set; } // hace referencia al calculo anterior

        public virtual ChristmasBonusAccrual? ReplacesAccrual { get; set; }
    }
}