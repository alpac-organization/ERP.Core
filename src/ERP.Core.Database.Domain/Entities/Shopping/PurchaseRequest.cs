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

        public DateOnly RequestDate { get; set; }
        public DateOnly? RevisionDate { get; set; }
        public PurchaseRequestType RequestType { get; set; }
        public PurchaseRequestStatus RequestStatus { get; set; } = PurchaseRequestStatus.Pending;

        public string? ReasonRejection { get; set; }

        public Guid? UserRevisionId { get; set; }
        public virtual User UserRevision { get; set; } = default!;

        public Guid RegisteredByUserId { get; set; }
        public virtual User RegistrationUser { get; set; } = default!;

        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;

        public Guid AreaId { get; set; }
        public virtual WorkArea WorkArea { get; set;} = default!;

        public virtual ICollection<PurchaseRequestItem> PurchaseRequestItems { get; set; } = [];

        public virtual RequisitionAccountingReview? AccountingReview { get; set; }

        public virtual RequisitionManagementReview? ManagementReview { get; set; }
    }
}
