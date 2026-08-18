using NanoidDotNet;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;

using ERP.Core.Infrastructure.Settings;
using ERP.Core.Application.Commons.Interfaces;
using ERP.Core.Application.Commons.Interfaces.AWS;

namespace ERP.Core.Infrastructure.Services
{
    public partial class S3StorageService(IAmazonS3 _s3Client, IOptions<S3Settings> _options, IErrorManager _errorManager) : IS3StorageService
    {
        private static readonly string[] AllowedExtensions = ["png", "jpg", "jpeg", "webp", "gif"];

        [GeneratedRegex(@"^data:image/(?<ext>[a-zA-Z0-9.+-]+);base64,")]
        private static partial Regex DataUriPrefix();

        public async Task<string> UploadImageAsync(string module, string section, string base64Image, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(base64Image))
            {
                return _errorManager.ThrowBadRequest<string>("La imagen en base64 es requerida.", "S3_Storage_Error");
            }

            var folder = BuildFolder(module, section);

            var base64Data = base64Image.Trim();

            var match = DataUriPrefix().Match(base64Data);

            string? extension = null;

            if (match.Success)
            {
                extension = NormalizeExtension(match.Groups["ext"].Value);
                base64Data = base64Data[match.Length..];
            }

            byte[] bytes;

            try
            {
                bytes = Convert.FromBase64String(base64Data);
            }
            catch (FormatException)
            {
                return _errorManager.ThrowBadRequest<string>("El base64 de la imagen no es válido.", "S3_Storage_Error");
            }

            if (bytes.Length == 0)
            {
                return _errorManager.ThrowBadRequest<string>("El contenido de la imagen está vacío.", "S3_Storage_Error");
            }

            extension ??= DetectExtension(bytes);

            if (extension is null || !AllowedExtensions.Contains(extension))
            {
                return _errorManager.ThrowBadRequest<string>($"El formato de la imagen no es permitido. Formatos soportados: {string.Join(", ", AllowedExtensions)}.", "S3_Storage_Error");
            }

            var contentType = extension switch
            {
                "png" => "image/png",
                "webp" => "image/webp",
                "gif" => "image/gif",
                _ => "image/jpeg"
            };

            var settings = _options.Value;
            var key = $"{folder}/{Nanoid.Generate(size: 12)}.{extension}";

            try
            {
                using var stream = new MemoryStream(bytes);

                await _s3Client.PutObjectAsync(new PutObjectRequest
                {
                    BucketName = settings.BucketName,
                    Key = key,
                    InputStream = stream,
                    ContentType = contentType
                }, cancellationToken);
            }
            catch (AmazonS3Exception)
            {
                return _errorManager.ThrowInternalError<string>("Ocurrió un error al subir la imagen al bucket de S3.", "S3_Storage_Error");
            }

            return BuildPublicUrl(key);
        }

        public async Task<IReadOnlyList<string>> UploadImagesAsync(string module, string section, IEnumerable<string> base64Images, CancellationToken cancellationToken = default)
        {
            var images = base64Images?.ToList() ?? [];

            if (images.Count == 0)
            {
                return _errorManager.ThrowBadRequest<IReadOnlyList<string>>("Debe enviar al menos una imagen en base64.", "S3_Storage_Error");
            }

            var urls = new List<string>(images.Count);

            foreach (var image in images)
            {
                urls.Add(await UploadImageAsync(module, section, image, cancellationToken));
            }

            return urls;
        }

        private string BuildFolder(string module, string section)
        {
            var moduleSegment = SanitizeSegment(module, "modulo");
            var sectionSegment = SanitizeSegment(section, "seccion");

            return $"{moduleSegment}/{sectionSegment}";
        }

        private string SanitizeSegment(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return _errorManager.ThrowBadRequest<string>($"El parámetro '{fieldName}' es requerido para organizar la imagen en el bucket.", "S3_Storage_Error");
            }

            var normalized = RemoveAccents(value.Trim().ToLowerInvariant());

            var builder = new StringBuilder(normalized.Length);

            foreach (var c in normalized)
            {
                builder.Append(char.IsLetterOrDigit(c) ? c : '-');
            }

            var segment = builder.ToString().Trim('-');

            while (segment.Contains("--"))
            {
                segment = segment.Replace("--", "-");
            }

            if (segment.Length == 0)
            {
                return _errorManager.ThrowBadRequest<string>($"El parámetro '{fieldName}' no contiene caracteres válidos.", "S3_Storage_Error");
            }

            return segment;
        }

        private static string RemoveAccents(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder(normalized.Length);

            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(c);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }

        private static string? NormalizeExtension(string extension)
        {
            return extension.Trim().ToLowerInvariant();
        }

        private static string? DetectExtension(byte[] bytes)
        {
            if (bytes.Length >= 4 && bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47)
            {
                return "png";
            }

            if (bytes.Length >= 3 && bytes[0] == 0xFF && bytes[1] == 0xD8 && bytes[2] == 0xFF)
            {
                return "jpg";
            }

            if (bytes.Length >= 4 && bytes[0] == 0x47 && bytes[1] == 0x49 && bytes[2] == 0x46 && bytes[3] == 0x38)
            {
                return "gif";
            }

            if (bytes.Length >= 12 && bytes[0] == 0x52 && bytes[1] == 0x49 && bytes[2] == 0x46 && bytes[3] == 0x46
                && bytes[8] == 0x57 && bytes[9] == 0x45 && bytes[10] == 0x42 && bytes[11] == 0x50)
            {
                return "webp";
            }

            return null;
        }

        private string BuildPublicUrl(string key)
        {
            var settings = _options.Value;

            if (!string.IsNullOrWhiteSpace(settings.PublicKeyBaseUrl))
            {
                return $"{settings.PublicKeyBaseUrl.TrimEnd('/')}/{key}";
            }

            if (!string.IsNullOrWhiteSpace(settings.ServiceUrl))
            {
                return $"{settings.ServiceUrl.TrimEnd('/')}/{settings.BucketName}/{key}";
            }

            return $"https://{settings.BucketName}.s3.{settings.Region}.amazonaws.com/{key}";
        }
    }
}
