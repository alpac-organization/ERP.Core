using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Domain.Entities.Accounting
{
    /// <summary>
    /// Solicitudes de compras revisadas por contabilidad here.
    /// </summary>
    public class PurchaseRequestsReviewedAccounting : BaseEntity<Guid>
    {
        public string? Comments { get; set; }
        public DateOnly SentToReviewAt  { get; set; }

        public AccountingReviewStatus Status { get; set; } = AccountingReviewStatus.Pending;

        /// <summary>
        /// Usuario que la envio a revisión.
        /// </summary>
        public Guid SentByUserId { get; set; }
        public virtual User SentByUser { get; set; } = default!;
        
        /// <summary>
        /// Persona de contabilidad encarga de revisar la solicitud.
        /// </summary>
        public Guid? ReviewedByUserId { get; set; }
        public virtual User? ReviewedByUser { get; set; }
        
        public Guid PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; } = default!;
    }
}
