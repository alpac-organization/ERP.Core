namespace ERP.Core.Infrastructure.Settings
{
    /// <summary>
    /// Configuración de Amazon SNS para el envío de notificaciones push vía FCM (HTTP v1).
    /// Reemplaza a FirebaseSettings, que ya no es necesario porque SNS administra
    /// las credenciales de Firebase (service.json) internamente en la Platform Application.
    /// </summary>
    public class AwsSnsSettings
    {
        /// <summary>
        /// Región de AWS donde vive el recurso SNS. Ej: "us-east-1".
        /// </summary>
        public string Region { get; set; } = default!;

        /// <summary>
        /// ARN de la Platform Application configurada en SNS con las credenciales de Firebase (token/service.json).
        /// Ej: arn:aws:sns:us-east-1:123456789012:app/GCM/MiApp
        /// </summary>
        public string PlatformApplicationArn { get; set; } = default!;

        /// <summary>
        /// (Opcional) ARN de un tópico SNS si envías notificaciones masivas por tópico.
        /// No es obligatorio si solo usas SendToTopicAsync con topics de FCM (no de SNS).
        /// </summary>
        public string? DefaultTopicArn { get; set; }

        /// <summary>
        /// (Opcional) Access Key / Secret Key si no usas roles IAM (EC2/ECS/Lambda con rol asignado).
        /// Se recomienda dejar esto vacío y usar credenciales por rol IAM en producción.
        /// </summary>
        public string? AccessKey { get; set; }
        public string? SecretKey { get; set; }
    }
}