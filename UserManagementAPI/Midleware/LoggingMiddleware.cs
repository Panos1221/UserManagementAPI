using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    // Constructor to initialize the middleware with the next middleware and the logger.
    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    // Main method to handle the HTTP request and log details.
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Incoming request: {method} {path}", context.Request.Method, context.Request.Path);

        await _next(context);

        _logger.LogInformation("Outgoing response: {statusCode}", context.Response.StatusCode);
    }
}
