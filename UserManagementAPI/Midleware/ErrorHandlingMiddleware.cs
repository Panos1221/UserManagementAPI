using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next; // The next middleware in the HTTP request pipeline

    // Constructor that initializes the middleware with the next middleware delegate.
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // Main method to process the HTTP request.
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    // Handles exceptions and sends a user-friendly error response.
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new { error = "Internal server error." });
        return context.Response.WriteAsync(result);
    }
}
