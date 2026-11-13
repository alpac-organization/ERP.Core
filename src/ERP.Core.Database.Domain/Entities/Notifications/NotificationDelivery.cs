using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Notifications
{
    public class NotificationDelivery : BaseEntity<Guid>
    {
        public Guid OutboxId { get; set; }
        public virtual NotificationOutbox Outbox { get; set; } = default!;

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = default!;

        public string? Channel { get; set; }

        public string? Status { get; set; }

        public string? IdempotencyKey { get; set; }

        public DateTime? SentAt { get; set; }

        public string? Error { get; set; }
    }
}
