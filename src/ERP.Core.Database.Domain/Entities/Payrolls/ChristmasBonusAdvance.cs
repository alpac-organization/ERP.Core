using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ChristmasBonusAdvance : BaseEntity<Guid>
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

        public Guid? RequestedById { get; set; }

        public virtual User? RequestedBy { get; set; }

        public DateOnly? ApprovedAt { get; set; }

        public Guid? ApprovedById { get; set; }

        public virtual User? ApprovedBy { get; set; }

        public DateOnly? PaidAt { get; set; }

        public Guid? PaidById { get; set; }

        public virtual User? PaidBy { get; set; }

        public DateOnly? CancelledAt { get; set; }

        public Guid? CancelledById { get; set; }

        public virtual User? CancelledBy { get; set; }

        public string? CancellationReason { get; set; }
    }
}
