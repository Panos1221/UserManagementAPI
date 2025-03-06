namespace UserManagementAPI.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMiddleware> _logger;

        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        // Handles each HTTP request in the pipeline.
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Validate the token (this is a placeholder for testing, implement your own token validation logic)
            if (token != "validTokenYay")
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
            // If the token is valid, proceed to the next middleware in the pipeline.
            await _next(context);
        }
    }
}