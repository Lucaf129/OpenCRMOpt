using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenCRMOptApp.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Continua la pipeline di middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                // Gestisce l'eccezione sollevata da middleware/controller successivi
                _logger.LogError(ex, "Si è verificato un errore inatteso.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Imposta il codice di stato HTTP a 500 (Internal Server Error)
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            // È possibile personalizzare il messaggio di errore o restituire un oggetto JSON
            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = exception.Message
            };

            var errorResponseJson = JsonSerializer.Serialize(errorResponse);

            return context.Response.WriteAsync(errorResponseJson);
        }
    }
}


