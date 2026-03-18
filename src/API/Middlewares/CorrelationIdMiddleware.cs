using Serilog.Context;
using System.Security.Claims;

namespace Elsekily.API.Middlewares;

/// <summary>
/// Pushes TraceIdentifier and UserId into the Serilog log context for structured logging.
/// </summary>
public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;

    public CorrelationIdMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        using (LogContext.PushProperty("TraceIdentifier", context.TraceIdentifier))
        using (LogContext.PushProperty("UserId", userId ?? "Anonymous"))
        {
            await _next(context);
        }
    }
}
