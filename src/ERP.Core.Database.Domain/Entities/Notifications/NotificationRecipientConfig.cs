using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Notifications
{
    public class NotificationRecipientConfig : BaseEntity<Guid>
    {
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        public Guid? BranchId { get; set; }
        public virtual Branch? Branch { get; set; }

        public int Module { get; set; }

        public string? EventKey { get; set; }

        public NotificationRecipientType RecipientType { get; set; }

        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }

        public Guid? RoleId { get; set; }
        public virtual Role? Role { get; set; }

        public bool SendEmail { get; set; } = true;
        public bool SendPush { get; set; } = true;

        public bool IsActive { get; set; } = true;
    }
}
