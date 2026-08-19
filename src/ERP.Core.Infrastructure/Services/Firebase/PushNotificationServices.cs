using FirebaseAdmin;
using FirebaseAdmin.Messaging;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Json;

using Microsoft.Extensions.Options;

using ERP.Core.Application.Commons.Interfaces.Firebase;
using ERP.Core.Infrastructure.Settings;

namespace ERP.Core.Infrastructure.Services.Firebase
{
    public class PushNotificationServices : IPushNotificationServices
    {
        private readonly FirebaseMessaging _messaging;

        public PushNotificationServices(IOptions<FirebaseSettings> options)
        {
            var settings = options.Value;

            if (string.IsNullOrWhiteSpace(settings.ProjectId) ||
                string.IsNullOrWhiteSpace(settings.ClientEmail) ||
                string.IsNullOrWhiteSpace(settings.PrivateKey))
            {
                throw new InvalidOperationException("No se encontró la configuración 'Firebase' (ProjectId, ClientEmail o PrivateKey).");
            }

            var app = FirebaseApp.DefaultInstance is not null
                ? FirebaseApp.DefaultInstance
                : FirebaseApp.Create(new AppOptions
                {
                    ProjectId = settings.ProjectId,
                    Credential = CredentialFactory
                        .FromJson<ServiceAccountCredential>(NewtonsoftJsonSerializer.Instance.Serialize(new JsonCredentialParameters
                        {
                            Type = settings.Type,
                            ProjectId = settings.ProjectId,
                            PrivateKeyId = settings.PrivateKeyId,
                            PrivateKey = settings.PrivateKey?.Replace("\\n", "\n"),
                            ClientEmail = settings.ClientEmail,
                            ClientId = settings.ClientId,
                            TokenUri = settings.TokenUri,
                        }))
                        .ToGoogleCredential(),
                });

            _messaging = FirebaseMessaging.GetMessaging(app);
        }

        public async Task<bool> SendAsync(string deviceToken, string title, string body, Dictionary<string, string>? data = null)
        {
            if (string.IsNullOrWhiteSpace(deviceToken))
            {
                return false;
            }

            var message = new Message
            {
                Fid = deviceToken,
                Notification = new Notification
                {
                    Title = title,
                    Body = body,
                },
                Data = data,
            };

            await _messaging.SendAsync(message);

            return true;
        }

        public async Task<bool> SendToTopicAsync(string topic, string title, string body, Dictionary<string, string>? data = null)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                return false;
            }

            var message = new Message
            {
                Topic = topic,
                Notification = new Notification
                {
                    Title = title,
                    Body = body,
                },
                Data = data,
            };

            await _messaging.SendAsync(message);

            return true;
        }
    }
}