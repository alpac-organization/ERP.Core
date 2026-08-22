namespace ERP.Core.Infrastructure.Settings
{
    public class S3Settings
    {
        public string BucketName { get; set; } = string.Empty;
        public string Region { get; set; } = "us-east-1";
        public string? AccessKey { get; set; }
        public string? SecretKey { get; set; }
        public string? ServiceUrl { get; set; }
        public string? PublicKeyBaseUrl { get; set; }
        public bool ForcePathStyle { get; set; } = true;
    }
}
