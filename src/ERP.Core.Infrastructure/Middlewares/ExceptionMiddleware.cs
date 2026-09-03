using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ERP.Core.Domain.Entities.Exceptions;

namespace ERP.Core.Infrastructure.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate _next, ILogger<ExceptionMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CoreException ex)
            {
                _logger.LogWarning(ex,
                    "Excepción controlada [{TypeError}] para {Method} {Path}{Query} (status {StatusCode})",
                    ex.ErrorData.Error.TypeError, context.Request.Method, context.Request.Path, context.Request.QueryString, ex.ErrorData.Status);

                // Aquí capturamos tu ErrorResponse personalizado
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Excepción no controlada (500) para {Method} {Path}{Query} - User: {UserId}",
                    context.Request.Method, context.Request.Path, context.Request.QueryString, context.User.Identity?.Name);

                // Error genérico para cosas que no controlamos (500)
                await HandleInternalExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, CoreException exception)
        {
            context.Response.ContentType = "application/json";
            
            // CAMBIO: Cambia .ErrorResponse por .ErrorData
            context.Response.StatusCode = exception.ErrorData.Status;

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            
            // CAMBIO: Aquí también usa .ErrorData
            var result = JsonSerializer.Serialize(exception.ErrorData, options);

            return context.Response.WriteAsync(result);
        }

        private static Task HandleInternalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            // Creamos un ErrorResponse manual para errores de servidor
            var response = new { 
                Status = 500, 
                Error = new { TypeError = "Server_Error", Description = "Error interno no controlado." },
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}