using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using UrlShortener.Helpers.Interfaces;

namespace UrlShortener.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInfo(
                    "Request {method} {url} => {statusCode}. { context.Request?.Method}. { context.Request?.Path.Value }. { context.Response?.StatusCode)}.");
            }
        }
    }
}
