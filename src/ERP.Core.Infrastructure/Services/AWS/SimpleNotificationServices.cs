using System.Text.Json;
using System.Text.RegularExpressions;

using ERP.Core.Domain.Enums;
using ERP.Core.Domain.Entities.AWS;
using ERP.Core.Infrastructure.Settings;
using ERP.Core.Application.Commons.Interfaces.AWS;

using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;

namespace ERP.Core.Infrastructure.Services.AWS
{
    public class SimpleNotificationServices : ISimpleNotificationServices
    {
        private readonly IAmazonSimpleNotificationService _sns;
        private readonly ILogger<SimpleNotificationServices> _logger;
        private readonly AwsSnsSettings _settings;

        public SimpleNotificationServices(IOptions<AwsSnsSettings> options, ILogger<SimpleNotificationServices> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _settings = options.Value;

            if (string.IsNullOrWhiteSpace(_settings.PlatformApplicationArn) || string.IsNullOrWhiteSpace(_settings.Region))
            {
                throw new InvalidOperationException("No se encontró la configuración 'AwsSns' (Region o PlatformApplicationArn).");
            }

            _sns = string.IsNullOrWhiteSpace(_settings.AccessKey)
                ? new AmazonSimpleNotificationServiceClient(RegionEndpoint.GetBySystemName(_settings.Region))
                : new AmazonSimpleNotificationServiceClient(
                    _settings.AccessKey,
                    _settings.SecretKey,
                    RegionEndpoint.GetBySystemName(_settings.Region));
        }

        public async Task<string?> RegisterDeviceAsync(string fcmToken, string? customUserData = null)
        {
            if (string.IsNullOrWhiteSpace(fcmToken))
            {
                return null;
            }

            try
            {
                var response = await _sns.CreatePlatformEndpointAsync(new CreatePlatformEndpointRequest
                {
                    Token                  = fcmToken,
                    PlatformApplicationArn = _settings.PlatformApplicationArn,
                    CustomUserData         = customUserData
                });

                return response.EndpointArn;
            }
            catch (InvalidParameterException ex)
            {
                var existingArn = ExtractExistingEndpointArn(ex.Message);

                if (existingArn is not null)
                {
                    _logger.LogInformation("SNS: el token ya tenía un endpoint registrado ({EndpointArn}). Se reutiliza.", existingArn);

                    await _sns.SetEndpointAttributesAsync(new SetEndpointAttributesRequest
                    {
                        EndpointArn = existingArn,
                        Attributes = new Dictionary<string, string>
                        {
                            ["Token"]          = fcmToken,
                            ["Enabled"]        = "true",
                            ["CustomUserData"] = customUserData ?? string.Empty
                        }
                    });

                    return existingArn;
                }

                _logger.LogError(ex, "SNS: parámetro inválido al crear el endpoint para el token {TokenPrefix}.", GetTokenPrefix(fcmToken));
                return null;
            }
            catch (AmazonSimpleNotificationServiceException ex)
            {
                _logger.LogError(ex, "SNS: error creando el endpoint para el token {TokenPrefix} (ErrorCode: {ErrorCode}).", GetTokenPrefix(fcmToken), ex.ErrorCode);
                return null;
            }
        }

        public async Task<bool> UnregisterDeviceAsync(string endpointArn)
        {
            if (string.IsNullOrWhiteSpace(endpointArn))
            {
                return false;
            }

            try
            {
                await _sns.DeleteEndpointAsync(new DeleteEndpointRequest { EndpointArn = endpointArn });
                return true;
            }
            catch (NotFoundException)
            {
                return true;
            }
            catch (AmazonSimpleNotificationServiceException ex)
            {
                _logger.LogError(ex, "SNS: error eliminando el endpoint {TokenPrefix}.", GetTokenPrefix(endpointArn));
                return false;
            }
        }
        
        public async Task<PushSendResult> SendPushNotificationAsync(string endpointArn, NotificationRequest notificationRequest, Dictionary<string, string>? data = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(endpointArn))
                {
                    return PushSendResult.Failed;
                }

                var messagePayload = BuildFcmV1Payload(notificationRequest, data);

                var jsonMessage = JsonSerializer.Serialize(new Dictionary<string, string>
                {
                    ["default"] = notificationRequest.Body ?? "Notification",
                    ["GCM"] = JsonSerializer.Serialize(messagePayload)
                });

                var request = new PublishRequest
                {
                    TargetArn = endpointArn,
                    Message = jsonMessage,
                    MessageStructure = "json"
                };

                await _sns.PublishAsync(request);
                return PushSendResult.Sent;
            }
            catch (EndpointDisabledException ex)
            {
                // El endpoint quedó deshabilitado porque FCM reportó el token como inválido/no registrado.
                _logger.LogWarning(ex, "Push SNS: el endpoint {TokenPrefix} está deshabilitado (token inválido/no registrado).", GetTokenPrefix(endpointArn));
                return PushSendResult.InvalidToken;
            }
            catch (NotFoundException ex)
            {
                // El EndpointArn no existe (pudo haber sido eliminado).
                _logger.LogWarning(ex, "Push SNS: el endpoint {TokenPrefix} no existe.", GetTokenPrefix(endpointArn));
                return PushSendResult.InvalidToken;
            }
            catch (AmazonSimpleNotificationServiceException ex)
            {
                _logger.LogError(ex, "Push SNS: error enviando notificación a {TokenPrefix} (ErrorCode: {ErrorCode}).", GetTokenPrefix(endpointArn), ex.ErrorCode);
                return PushSendResult.Failed;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Push SNS: error inesperado enviando notificación a {TokenPrefix}.", GetTokenPrefix(endpointArn));
                return PushSendResult.Failed;
            }
        }

        public async Task<bool> SendToTopicAsync(string topicArn, string title, string body, Dictionary<string, string>? data = null)
        {
            if (string.IsNullOrWhiteSpace(topicArn))
            {
                return false;
            }

            try
            {
                var notificationRequest = new NotificationRequest { Title = title, Body = body };
                var messagePayload = BuildFcmV1Payload(notificationRequest, data);

                var jsonMessage = JsonSerializer.Serialize(new Dictionary<string, string>
                {
                    ["default"] = body,
                    ["GCM"] = JsonSerializer.Serialize(messagePayload)
                });

                await _sns.PublishAsync(new PublishRequest
                {
                    TopicArn = topicArn,
                    Message = jsonMessage,
                    MessageStructure = "json"
                });

                return true;
            }
            catch (AmazonSimpleNotificationServiceException ex)
            {
                _logger.LogError(ex, "Push SNS: error enviando notificación al tópico {TopicArn} (ErrorCode: {ErrorCode}).", topicArn, ex.ErrorCode);
                return false;
            }
        }

        #region Private Methods
        #region Private Methods
        private static object BuildFcmV1Payload(NotificationRequest notificationRequest, Dictionary<string, string>? data)
        {
            var customData = data ?? new Dictionary<string, string>();

            return new
            {
                fcmV1Message = new
                {
                    message = new
                    {
                        data = customData,
                        android = new
                        {
                            priority = "high",
                            notification = new
                            {
                                visibility = "PUBLIC",
                                notification_priority = "PRIORITY_MAX",
                                title = notificationRequest.Title,
                                body  = notificationRequest.Body,
                                icon  = notificationRequest.AndroidConfig?.Icon,
                                image = notificationRequest.ImageUrl
                            }
                        },
                        webpush = new
                        {
                            headers = new
                            {
                                Urgency = "high"
                            },
                            notification = new
                            {
                                title = notificationRequest.Title,
                                body  = notificationRequest.Body,
                                icon  = notificationRequest.WebPushConfig?.Icon,
                                badge = notificationRequest.WebPushConfig?.Badge,
                                image = notificationRequest.ImageUrl,
                                tag   = "pwa-notification",
                                renotify = true,
                                requireInteraction = true
                            },
                            data = customData
                        }
                    }
                }
            };
        }
        #endregion

        private static string? ExtractExistingEndpointArn(string errorMessage)
        {
            var match = Regex.Match(errorMessage, @"arn:aws:sns:[^""'\s]+:endpoint/[^""'\s]+");
            return match.Success ? match.Value : null;
        }

        private static string GetTokenPrefix(string value)
        {
            return value.Length > 12 ? value[..12] : value;
        }
        #endregion
    }
}