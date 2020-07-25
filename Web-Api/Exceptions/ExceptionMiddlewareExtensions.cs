using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using CrossLayersUtils;
using CrossLayersUtils.Utils;
using Microsoft.Extensions.Logging;

namespace Web_Api.Exceptions
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

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger logger)
        {
            //   throw ex;
            var code = ex switch
            {
                NotFoundException _ => HttpStatusCode.NotFound,
                InvalidCredentialException _ => HttpStatusCode.Forbidden,
                AuthenticationException _ => HttpStatusCode.Unauthorized,
                InvalidStateException _ => HttpStatusCode.BadRequest,
                IllegalArgumentException _ => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

            var logErrMsg = $"{ex.Message} - {context.Request.Path}{context.Request.QueryString}";
            if (code == HttpStatusCode.InternalServerError)
                logger.LogError(logErrMsg);
            else
                logger.LogInformation(logErrMsg);
            
            var result = JsonConvert.SerializeObject(new {error = ex.Message});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(result);
        }
    }
}