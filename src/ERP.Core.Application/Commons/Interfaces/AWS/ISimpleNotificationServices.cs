using ERP.Core.Domain.Enums;
using ERP.Core.Domain.Entities.AWS;

namespace ERP.Core.Application.Commons.Interfaces.AWS
{
    public interface ISimpleNotificationServices
    {
        /// <summary>
        /// Registra un dispositivo en AWS SNS y devuelve el EndpointArn correspondiente.
        /// </summary>
        /// <param name="fcmToken"></param>
        /// <param name="customUserData"></param>
        /// <returns></returns>
        Task<string?> RegisterDeviceAsync(string fcmToken, string? customUserData = null);

        /// <summary>
        /// Desregistra un dispositivo de AWS SNS utilizando su EndpointArn.
        /// </summary>
        /// <param name="endpointArn"></param>
        /// <returns></returns>
        Task<bool> UnregisterDeviceAsync(string endpointArn);

        /// <summary>
        /// Envia una notificación push a un dispositivo específico utilizando AWS SNS.
        /// </summary>
        /// <param name="endpointArn"></param>
        /// <param name="notificationRequest"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<PushSendResult> SendPushNotificationAsync(string endpointArn, NotificationRequest notificationRequest, Dictionary<string, string>? data = null);

        /// <summary>
        /// Envía una notificación a un tema específico en AWS SNS.
        /// </summary>
        /// <param name="topicArn"></param>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> SendToTopicAsync(string topicArn, string title, string body, Dictionary<string, string>? data = null);
    }
}