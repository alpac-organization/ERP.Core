using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class PurchaseRequest : BaseEntity<Guid>
    {
        public string? Code { get; set; }
        public DateOnly RequestDate { get; set; }
        public PurchaseRequestType RequestType { get; set; }
        public PurchaseRequestStatus RequestStatus { get; set; } = PurchaseRequestStatus.Pending;

        public string? Justification { get; set; }
        public string? ReasonRejection { get; set; }
        public DateOnly? RevisionDate { get; set; }

        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = default!;

        public virtual ICollection<RequestedProduct> RequestdProducts { get; set; } = [];
        public virtual ICollection<RequestQuotedPurchases> RequestQuotedPurchases { get; set; } = [];
    }
}
