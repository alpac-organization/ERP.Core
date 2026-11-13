using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Notifications
{
    public class NotificationOutbox : BaseEntity<Guid>
    {
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        public Guid? BranchId { get; set; }
        public virtual Branch? Branch { get; set; }

        public int Module { get; set; }

        public string? EventKey { get; set; }

        public string? Payload { get; set; }

        public string? Status { get; set; }

        public int Attempts { get; set; }

        public DateTime? NextAttemptAt { get; set; }
    }
}
