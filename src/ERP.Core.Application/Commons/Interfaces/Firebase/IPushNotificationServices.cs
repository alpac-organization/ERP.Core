using ERP.Core.Domain.Entities.Firebase;
using ERP.Core.Domain.Enums;

namespace ERP.Core.Application.Commons.Interfaces.Firebase
{
    public interface IPushNotificationServices
    {
        Task<PushSendResult> SendAsync(string deviceToken, NotificationRequest notificationRequest, Dictionary<string, string>? data = null);
        Task<bool> SendToTopicAsync(string topic, string title, string body, Dictionary<string, string>? data = null);
    }
}