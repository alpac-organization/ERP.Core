namespace ERP.Core.Domain.Entities.Services
{
    public class Camera
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string IpAddress { get; set; } = default!;
        public int Channel { get; set; } = 1;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;

        public string BuildRtspUrl() => $"rtsp://{IpAddress}:554/Streaming/Channels/{Channel}01";
    }
}