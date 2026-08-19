using Amazon;
using Amazon.S3;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ERP.Core.Infrastructure.Services;
using ERP.Core.Infrastructure.Settings;

using ERP.Core.Infrastructure.Services.AWS;
using ERP.Core.Infrastructure.Services.Firebase;

using ERP.Core.Application.Commons.Interfaces.AWS;
using ERP.Core.Application.Commons.Interfaces.Firebase;

namespace ERP.Core.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddErpCoreServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<S3Settings>(configuration.GetSection(S3Settings.SectionName));
            services.Configure<FirebaseSettings>(configuration.GetSection(FirebaseSettings.SectionName));

            var firebaseSettings = configuration.GetSection(FirebaseSettings.SectionName).Get<FirebaseSettings>()
                ?? throw new InvalidOperationException("No se encontró la sección de configuración 'Firebase'.");

            var settings = configuration.GetSection(S3Settings.SectionName).Get<S3Settings>()
                ?? throw new InvalidOperationException("No se encontró la sección de configuración 'S3Storage'.");

            if (string.IsNullOrWhiteSpace(settings.BucketName))
            {
                throw new InvalidOperationException("No se encontró la configuración 'S3Storage:BucketName'.");
            }

            services.AddSingleton<IAmazonS3>(_ =>
            {
                var clientConfig = new AmazonS3Config
                {
                    RegionEndpoint = RegionEndpoint.GetBySystemName(string.IsNullOrWhiteSpace(settings.Region) ? "us-east-1" : settings.Region),
                    ForcePathStyle = settings.ForcePathStyle
                };

                if (!string.IsNullOrWhiteSpace(settings.ServiceUrl))
                {
                    clientConfig.ServiceURL = settings.ServiceUrl;
                }

                return string.IsNullOrWhiteSpace(settings.AccessKey) || string.IsNullOrWhiteSpace(settings.SecretKey)
                    ? new AmazonS3Client(clientConfig)
                    : new AmazonS3Client(settings.AccessKey, settings.SecretKey, clientConfig);
            });

            services.AddScoped<IS3StorageService, S3StorageService>();
            services.AddScoped<IPushNotificationServices, PushNotificationServices>();

            return services;
        }
    }
}
