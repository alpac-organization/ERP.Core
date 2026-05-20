using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class DeductionPaymentHistory : BaseEntity<Guid>
    {
        public DateTime PaymentDate { get; set; }
        
        public Currency Currency { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountPaidInDollars { get; set; }

        public DeductionPaymentStatus Status { get; set; }
        public SourceDeductionPayment Origin { get; set; }
        
        //Nos ayuda a lograr identificar en que periodo de nomina se dedujo esa cantidad al colaborador.
        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = null!;
        
        public Guid DeductionId { get; set; }
        public virtual Deduction Deduction { get; set; } = null!;
    }
}