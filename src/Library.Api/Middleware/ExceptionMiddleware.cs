using System.Net;
using System.Text.Json;
using Library.Application.Exceptions;

namespace Library.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            await WriteErrorAsync(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (BadRequestException ex)
        {
            await WriteErrorAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (ConflictException ex)
        {
            await WriteErrorAsync(context, HttpStatusCode.Conflict, ex.Message);
        }
        catch (Exception ex)
        {
            // Generic fallback — do NOT expose stack traces to clients
            await WriteErrorAsync(context, HttpStatusCode.InternalServerError,
                "An unexpected error occurred.");

            // Log the real exception server-side (console here; swap for ILogger in production)
            Console.Error.WriteLine($"[{DateTime.UtcNow:u}] Unhandled exception: {ex}");
        }
    }

    private static async Task WriteErrorAsync(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        // Assignment-required format: { "error": "message here" }
        var response = new { error = message };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}