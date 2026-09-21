using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    /// <summary>
    /// Factura emitida para op
    /// </summary>
    public class Invoice : BaseEntity<Guid>
    {
        public string? Status { get; set; }
        public string? InvoiceCode { get; set; }
        
        public decimal? Discount { get; set; }
        public decimal? DiscountPercentage { get; set; }

        public decimal TotalAmount { get; set;  }

        public DateOnly? DueDate { get; set; }
        public DateOnly? DateIssued { get; set; }
        
        public virtual Guid OperationalOrderId { get; set; } 
        public virtual OperationalOrder OperationalOrder { get; set; } = default!;
        
    }
}