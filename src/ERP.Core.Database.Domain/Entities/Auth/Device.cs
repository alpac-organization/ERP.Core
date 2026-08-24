using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Auth
{
    public class Device: BaseEntity<Guid>
    {
        public bool IsActive { get; set; }

        public string? FcmToken { get; set; }
        public string? EndpointArn { get; set; }
        public string? DeviceName { get; set; }

        public Guid UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; } = default!;
    }

}