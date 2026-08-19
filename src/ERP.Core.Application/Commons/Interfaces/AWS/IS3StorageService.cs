namespace ERP.Core.Application.Commons.Interfaces.AWS
{
    public interface IS3StorageService
    {
        Task<string> UploadImageAsync(string module, string section, string base64Image, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<string>> UploadImagesAsync(string module, string section, IEnumerable<string> base64Images, CancellationToken cancellationToken = default);

        Task DeleteImagesAsync(IEnumerable<string> imageUrls, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<string>> MoveImagesAsync(IEnumerable<string> sourceUrls, string sourceSection, string destinationSection, CancellationToken cancellationToken = default);
    }
}
