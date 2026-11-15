namespace ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

public class ChristmasBonusAdvance :BaseEntity<Guid> 
{

      public Guid ChristmasBonusPeriodId { get; set; }

        public virtual ChristmasBonusPeriod ChristmasBonusPeriod { get; set; } = default!;

        public Guid CollaboratorId { get; set; }

        public virtual Collaborator Collaborator { get; set; } = default!;

        public Guid? PayrollId { get; set; }

        public virtual Payroll? Payroll { get; set; }

        public Currency Currency { get; set; }

        public decimal Amount { get; set; }

        public decimal AmountInDollars { get; set; }


        public ChristmasBonusAdvanceStatus Status { get; set; }

        public DateOnly RequestedAt { get; set; }

        public string? RequestedBy { get; set; }

        public DateOnly? ApprovedAt { get; set; }

        public string? ApprovedBy { get; set; }

        public DateOnly? PaidAt { get; set; }

        public string? PaidBy { get; set; }

        public DateOnly? ReversedAt { get; set; }

        public string? ReversedBy { get; set; }

        public string? ReversalReason { get; set; }
}