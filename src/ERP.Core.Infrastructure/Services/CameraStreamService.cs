using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.Types.X.Sources;
using System.Collections.Concurrent;
using VisioForge.Core.MediaBlocks.VideoProcessing;

using SkiaSharp;
using ERP.Core.Domain.Entities.Services;
using ERP.Core.Application.Commons.Interfaces;

namespace ERP.Core.Infrastructure.Services
{
    public class VisioForgeCameraStreamService : ICameraStreamService
    {
        private static bool _sdkInitialized = false;
        private readonly ConcurrentDictionary<int, MediaBlocksPipeline> _pipelines = new();
        private static readonly SemaphoreSlim _sdkInitLock = new(1, 1);

        private static async Task EnsureSdkInitializedAsync()
        {
            if (_sdkInitialized) return;

            await _sdkInitLock.WaitAsync();
            try
            {
                if (!_sdkInitialized)
                {
                    await VisioForgeX.InitSDKAsync();
                    _sdkInitialized = true;
                }
            }
            finally
            {
                _sdkInitLock.Release();
            }
        }

        public async Task StartAsync(Camera camera, Func<byte[], Task> onFrameReceived, CancellationToken ct)
        {
            await EnsureSdkInitializedAsync();

            var pipeline = new MediaBlocksPipeline();

            var rtspSettings = await RTSPSourceSettings.CreateAsync(
                new Uri(camera.BuildRtspUrl()),
                camera.Username,
                camera.Password,
                false
            );

            rtspSettings.Latency = TimeSpan.FromMilliseconds(200);

            var rtspSource = new RTSPSourceBlock(rtspSettings);

            var sampleGrabber = new VideoSampleGrabberBlock(addNullRenderer: true);

            sampleGrabber.OnVideoFrameSKBitmap += async (s, e) =>
            {
                try
                {
                    using var image = SKImage.FromBitmap(e.Frame);
                    using var data = image.Encode(SKEncodedImageFormat.Jpeg, 80); // 80 = calidad JPEG
                    await onFrameReceived(data.ToArray());
                }
                catch
                {
                    //Manejo del error de sincronización                    
                }
            };

            pipeline.Connect(rtspSource.VideoOutput, sampleGrabber.Input);

            await pipeline.StartAsync();
            if (_pipelines.TryRemove(camera.Id, out var oldPipeline))
            {
                await oldPipeline.StopAsync();
                oldPipeline.Dispose();
            }

            _pipelines[camera.Id] = pipeline;
            ct.Register(async () => await StopAsync(camera.Id));
        }

        public async Task StopAsync(int cameraId)
        {
            if (_pipelines.TryRemove(cameraId, out var pipeline))
            {
                await pipeline.StopAsync();
                pipeline.Dispose();
            }
        }
    }
}