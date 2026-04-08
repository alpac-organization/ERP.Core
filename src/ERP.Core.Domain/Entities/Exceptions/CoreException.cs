using ERP.Core.Domain.Entities.Errors;

namespace ERP.Core.Domain.Entities.Exceptions
{
    /// <summary>
    /// Excepción base personalizada que transporta la entidad ErrorResponse 
    /// para ser capturada por el Middleware global.
    /// </summary>
    public class CoreException(ErrorResponse errorData) : Exception(errorData.Error.Description)
    {
        public ErrorResponse ErrorData { get; } = errorData;
    }
}