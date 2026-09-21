using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    /// <summary>
    /// Invoice issued for operational order
    /// </summary>
    public class Invoice : BaseEntity<Guid>
    {
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;
        public string? InvoiceCode { get; set; }
        
        public decimal? Discount { get; set; }
        public decimal? DiscountPercentage { get; set; }

        public decimal TotalAmount { get; set; }

        public DateOnly? DueDate { get; set; }
        public DateOnly? DateIssued { get; set; }
        
        public virtual Guid OperationalOrderId { get; set; } 
        public virtual OperationalOrder OperationalOrder { get; set; } = default!;
        
    }
}