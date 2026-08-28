namespace ERP.Core.Domain.Entities.AWS
{
    public class NotificationRequest
    {
        public string? Body { get; set; } = "body"; 
        public string? Title { get; set; } = "title";
        public string? ImageUrl { get; set; } = string.Empty;

        public WebPushConfig WebPushConfig { get; set; } = new ();
        public AndroidConfig AndroidConfig { get; set; } = new ();
    }

    public class BaseConfig
    {
        public string? Icon { get; set; } = "";
        public string? Badge { get; set; } = "";
    }

    public class WebPushConfig : BaseConfig { }
    public class AndroidConfig : BaseConfig { }
}