using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Notifications
{
    public class NotificationSenderConfig : BaseEntity<Guid>
    {
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        public Guid? BranchId { get; set; }
        public virtual Branch? Branch { get; set; }

        public int Module { get; set; }

        public string? FromEmail { get; set; }
        public string? FromName { get; set; }

        public string? SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string? SmtpUser { get; set; }
        public string? SmtpPasswordEnc { get; set; }
        public bool UseSsl { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
