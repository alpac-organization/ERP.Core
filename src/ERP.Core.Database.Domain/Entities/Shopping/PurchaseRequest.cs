using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class PurchaseRequest : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }

        public string? Code { get; set; }
        public string? Observations { get; set; }
        public string? ReasonRejection { get; set; }

        public DateOnly RequestDate { get; set; }
        public DateOnly? RevisionDate { get; set; }

        public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.None;
        public DestinationRequest Destination { get; set; } = DestinationRequest.Internal;
        public PurchaseRequestType RequestType { get; set; } = PurchaseRequestType.Requisition;
        public PurchaseRequestStatus RequestStatus { get; set; } = PurchaseRequestStatus.Pending;

        /// <summary>
        /// Usuario de revición
        /// </summary>
        public Guid? UserRevisionId { get; set; }
        public virtual User UserRevision { get; set; } = default!;

        /// <summary>
        /// Usuario solicitante
        /// </summary>
        public Guid RegisteredByUserId { get; set; }
        public virtual User RegistrationUser { get; set; } = default!;
        
        /// <summary>
        /// Sucursal que necesita la requisición
        /// </summary>
        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;

        /// <summary>
        /// Area Solicitante
        /// </summary>
        public Guid AreaId { get; set; }
        public virtual WorkArea WorkArea { get; set;} = default!;

        /// <summary>
        /// Auditoria de creación de requisiciónes
        /// </summary>
        public virtual RequisitionAccountingReview? AccountingReview { get; set; }
        public virtual RequisitionManagementReview? ManagementReview { get; set; }

        public virtual ICollection<PurchaseRequestItem> PurchaseRequestItems { get; set; } = [];
    }
}
