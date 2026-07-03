using ERP.Core.Domain.Entities.Services;

namespace ERP.Core.Application.Commons.Interfaces
{
    public interface ICameraStreamService
    {
        Task StartAsync(Camera camera, Func<byte[], Task> onFrameReceived, CancellationToken ct);
        Task StopAsync(int cameraId);
    }
}