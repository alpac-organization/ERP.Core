using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ChristmasBonusSettlement : BaseEntity<Guid>
    {
        public Guid ChristmasBonusPeriodId { get; set; }

        public virtual ChristmasBonusPeriod ChristmasBonusPeriod { get; set; }
            = default!;

        public Guid CollaboratorId { get; set; }

        public virtual Collaborator Collaborator { get; set; }
            = default!;

        public Guid CollaboratorPeriodId { get; set; }

        public virtual CollaboratorPeriod CollaboratorPeriod { get; set; } = default!;

        public Guid? PayrollId { get; set; }

        public virtual Payroll? Payroll { get; set; }

        public ChristmasBonusSettlementType Type { get; set; }

        public ChristmasBonusSettlementStatus Status { get; set; }

        public DateOnly CutoffDate { get; set; } //fecha hasta la cual se realizo el cálculo

        public SalaryType SalaryTypeSnapshot { get; set; }

        public decimal ReferenceSalary { get; set; } // Cual salario fue referenciado

        public decimal EligibleDays { get; set; } //Cuantos dias elegibles dentro del ciclo como tal

        public decimal ChristmasBonusDays { get; set; } // dias equivalentes

        public decimal GrossEntitlement { get; set; } // aguinaldo total antes de posibles adelantos

        public decimal AdvancesPaid { get; set; } // suma de los posibles adelantos pagados

        public decimal ChildSupportWithholding { get; set; } // aqui se toma en cuenta la posible retencion alimenticia a aguinaldo

        public decimal AmountToPay { get; set; } //cantidad a pagarj

        public decimal? AmountToPayInDollars { get; set; }


        public DateOnly? PaidAt { get; set; }

        public Guid? PaidById { get; set; }

        public virtual User? PaidBy { get; set; }

    }
}