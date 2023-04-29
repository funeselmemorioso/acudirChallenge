using System.Net;
using Acudir.Challenge.DTOs.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Acudir.Challenge.Middlewares
{
    public class ExceptionsMiddleware
    {
        ILogger<ExceptionsMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // La forma que se quiera manejar las exceptions aquí

            _logger.LogError(exception.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(new ErrorDetailsDTO()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());

           
        }
    }

   
}
