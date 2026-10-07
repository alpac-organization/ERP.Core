using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Auth
{
    public class Notification: BaseEntity<Guid>
    {
        public bool WasRead { get; set; } = false;
        
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? PathRedirect { get; set; }
        public string? AdditionalData { get; set; }
        
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = default!; 
    }

    public class NotificationAdditionalData
    {
    public string? EntityType { get; set; } 
    public Guid? EntityId { get; set; }     
    public PurchaseRequestNotificationInfo? PurchaseRequestInfo { get; set; }
    }

    public class PurchaseRequestNotificationInfo
    {
    public string? Code { get; set; } 
    public string? RequestType { get; set; } 
    public string? BranchName { get; set; }
    public string? AreaName { get; set; }
    public int TotalItems { get; set; }
    }
}