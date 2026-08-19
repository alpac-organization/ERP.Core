namespace ERP.Core.Infrastructure.Settings
{
    public class FirebaseSettings
    {
        public const string SectionName = "Firebase";

        public string Type { get; set; } = "service_account";
        public string ProjectId { get; set; } = string.Empty;
        public string PrivateKeyId { get; set; } = string.Empty;
        public string PrivateKey { get; set; } = string.Empty;
        public string ClientEmail { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string AuthUri { get; set; } = "https://accounts.google.com/o/oauth2/auth";
        public string TokenUri { get; set; } = "https://oauth2.googleapis.com/token";
        public string? AuthProviderX509CertUrl { get; set; }
        public string? ClientX509CertUrl { get; set; }
    }
}