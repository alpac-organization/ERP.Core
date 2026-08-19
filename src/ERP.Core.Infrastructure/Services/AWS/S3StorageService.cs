using NanoidDotNet;

using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;

using ERP.Core.Infrastructure.Settings;
using ERP.Core.Application.Commons.Interfaces;
using ERP.Core.Application.Commons.Interfaces.AWS;

namespace ERP.Core.Infrastructure.Services.AWS
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

        public async Task DeleteImagesAsync(IEnumerable<string> imageUrls, CancellationToken cancellationToken = default)
        {
            var urls = imageUrls?.ToList() ?? [];

            if (urls.Count == 0)
            {
                _errorManager.ThrowBadRequest<IReadOnlyList<string>>("Debe enviar al menos una URL de imagen.", "S3_Storage_Error");

                return;
            }

            var settings = _options.Value;

            foreach (var imageUrl in urls)
            {
                if (string.IsNullOrWhiteSpace(imageUrl))
                {
                    continue; // Saltar URLs vacías
                }

                var key = ExtractKeyFromUrl(imageUrl, settings);

                if (string.IsNullOrEmpty(key))
                {
                    _errorManager.ThrowBadRequest<IReadOnlyList<string>>(
                        $"La URL proporcionada no pertenece al bucket configurado: {imageUrl}",
                        "S3_Storage_Error");
                    return;
                }

                try
                {
                    await _s3Client.DeleteObjectAsync(new DeleteObjectRequest
                    {
                        BucketName = settings.BucketName,
                        Key = key
                    }, cancellationToken);
                }
                catch (AmazonS3Exception)
                {
                    _errorManager.ThrowInternalError<IReadOnlyList<string>>(
                        $"Ocurrió un error al eliminar la imagen: {imageUrl}",
                        "S3_Storage_Error");

                    return;
                }
            }
        }

        #region Move Images
        public async Task<IReadOnlyList<string>> MoveImagesAsync(, IEnumerable<string> sourceUrls, string sourceSection,
            string destinationSection, CancellationToken cancellationToken = default)
        {
            var urls = sourceUrls?.Distinct().ToList() ?? [];

            if (urls.Count == 0)
            {
                _errorManager.ThrowBadRequest<IReadOnlyList<string>>("Debe enviar al menos una URL de imagen.", "S3_Storage_Error");
                return [];
            }

            var settings = _options.Value;
            var sourceSectionSanitized = SanitizeSegment(sourceSection, "origen");
            var destinationSectionSanitized = SanitizeSegment(destinationSection, "destino");

            // FASE 1: Validar todas las URLs y derivar claves de destino
            var moveOperations = new List<(string SourceKey, string DestinationKey, string DestinationUrl)>();

            foreach (var sourceUrl in urls)
            {
                if (string.IsNullOrWhiteSpace(sourceUrl))
                {
                    continue;
                }

                var sourceKey = ExtractKeyFromUrl(sourceUrl, settings);

                if (string.IsNullOrEmpty(sourceKey))
                {
                    _errorManager.ThrowBadRequest<IReadOnlyList<string>>(
                        $"La URL proporcionada no pertenece al bucket configurado: {sourceUrl}",
                        "S3_Storage_Error");
                    return [];
                }

                // Validar que la key pertenezca a la sección de origen
                if (!sourceKey.StartsWith(sourceSectionSanitized))
                {
                    _errorManager.ThrowBadRequest<IReadOnlyList<string>>(
                        $"La URL no pertenece a la sección '{sourceSection}': {sourceUrl}",
                        "S3_Storage_Error");
                    return [];
                }

                // Derivar destino reemplazando solo el segmento de sección
                var relativePath = sourceKey[sourceSectionSanitized.Length..].TrimStart('/');
                var destinationKey = $"{destinationSectionSanitized}/{relativePath}";

                // Verificar que el destino no exista
                try
                {
                    await _s3Client.GetObjectMetadataAsync(new GetObjectMetadataRequest
                    {
                        BucketName = settings.BucketName,
                        Key = destinationKey
                    }, cancellationToken);

                    _errorManager.ThrowBadRequest<IReadOnlyList<string>>(
                        $"Ya existe un objeto en el destino: {destinationKey}",
                        "S3_Storage_Error");
                    return [];
                }
                catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // No existe, es seguro continuar
                }

                var destinationUrl = BuildPublicUrl(destinationKey);
                moveOperations.Add((sourceKey, destinationKey, destinationUrl));
            }

            // FASE 2: Copiar todos los objetos (sin eliminar origen todavía)
            var copiedOperations = new List<(string SourceKey, string DestinationKey, string DestinationUrl)>();

            try
            {
                foreach (var operation in moveOperations)
                {
                    await _s3Client.CopyObjectAsync(new CopyObjectRequest
                    {
                        SourceBucket = settings.BucketName,
                        SourceKey = operation.SourceKey,
                        DestinationBucket = settings.BucketName,
                        DestinationKey = operation.DestinationKey,
                        IfNoneMatch = "*"
                    }, cancellationToken);

                    copiedOperations.Add(operation);
                }
            }
            catch (AmazonS3Exception)
            {
                // Compensación: eliminar copias exitosas
                foreach (var copied in copiedOperations)
                {
                    try
                    {
                        await _s3Client.DeleteObjectAsync(new DeleteObjectRequest
                        {
                            BucketName = settings.BucketName,
                            Key = copied.DestinationKey
                        }, cancellationToken);
                    }
                    catch
                    {
                        // Si falla la limpieza, continuar
                    }
                }

                _errorManager.ThrowInternalError<IReadOnlyList<string>>(
                    "Ocurrió un error al mover las imágenes. Se revirtieron los cambios.",
                    "S3_Storage_Error");
                return [];
            }

            // FASE 3: Eliminar orígenes solo si todas las copias fueron exitosas
            var movedUrls = new List<string>();

            foreach (var operation in copiedOperations)
            {
                try
                {
                    await _s3Client.DeleteObjectAsync(new DeleteObjectRequest
                    {
                        BucketName = settings.BucketName,
                        Key = operation.SourceKey
                    }, cancellationToken);

                    movedUrls.Add(operation.DestinationUrl);
                }
                catch (AmazonS3Exception)
                {
                    _errorManager.ThrowInternalError<IReadOnlyList<string>>(
                        $"No se pudo eliminar el objeto original: {operation.SourceKey}. El objeto ya fue copiado a la papelera.",
                        "S3_Storage_Error");
                    return [];
                }
            }

            return movedUrls;
        }
        #endregion
        private static string ExtractKeyFromUrl(string imageUrl, S3Settings settings)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                return string.Empty;
            }

            // Intentar parsear la URL
            if (!Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri))
            {
                return string.Empty;
            }

            // Validar que la URL use HTTPS
            if (uri.Scheme != Uri.UriSchemeHttps)
            {
                return string.Empty;
            }

            var host = uri.Host.ToLowerInvariant();
            var path = uri.AbsolutePath.TrimStart('/');

            // Caso 1: URL pública con PublicKeyBaseUrl
            if (!string.IsNullOrWhiteSpace(settings.PublicKeyBaseUrl))
            {
                if (Uri.TryCreate(settings.PublicKeyBaseUrl, UriKind.Absolute, out var publicUri))
                {
                    var publicHost = publicUri.Host.ToLowerInvariant();
                    var publicPathPrefix = publicUri.AbsolutePath.TrimEnd('/');

                    if (host == publicHost)
                    {
                        if (string.IsNullOrEmpty(publicPathPrefix))
                        {
                            return path;
                        }
                        else if (uri.AbsolutePath.StartsWith(publicPathPrefix + "/"))
                        {
                            // CORREGIDO: Eliminar publicPathPrefix antes de retornar la key
                            return uri.AbsolutePath[(publicPathPrefix.Length + 1)..];
                        }
                    }
                }
            }
            // Caso 2: URL con ServiceUrl (puede ser http o https)
            if (!string.IsNullOrWhiteSpace(settings.ServiceUrl))
            {
                if (Uri.TryCreate(settings.ServiceUrl, UriKind.Absolute, out var serviceUri))
                {
                    var serviceHost = serviceUri.Host.ToLowerInvariant();
                    var servicePathPrefix = $"{serviceUri.AbsolutePath.TrimEnd('/')}/{settings.BucketName}";

                    if (host == serviceHost && uri.AbsolutePath.StartsWith(servicePathPrefix + "/"))
                    {
                        return uri.AbsolutePath[(servicePathPrefix.Length + 1)..];
                    }
                }
            }

            // Caso 3: URL estándar de S3
            var s3Host = $"{settings.BucketName}.s3.{settings.Region}.amazonaws.com";
            if (host == s3Host)
            {
                return path;
            }

            // Caso 4: URL virtual-hosted style
            var virtualHostedS3 = $"{settings.BucketName}.s3.amazonaws.com";
            if (host == virtualHostedS3)
            {
                return path;
            }

            // Si no coincide con ningún patrón autorizado, rechazar
            return string.Empty;
        }

        #region Private methods
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

        #endregion
    }
}
