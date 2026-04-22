using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class DeductionPaymentHistory
    {
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public SourceDeductionPayment Origin { get; set; }
        
        public Guid DeductionId { get; set; }
        public virtual Deduction Deduction { get; set; } = null!;
    }
}