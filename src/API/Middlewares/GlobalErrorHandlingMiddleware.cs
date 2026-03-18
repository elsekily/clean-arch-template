using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using Elsekily.Application.Common.Models;

namespace Elsekily.API.Middlewares;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

    public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
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

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var traceId = context.TraceIdentifier;
        var details = FlattenException(exception);
        _logger.LogError("Unhandled Exception. TraceId: {TraceId}\n{Exception}", traceId, details);

        var message = $"Something went wrong. Please provide TraceId: {traceId} to the support team.";
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync(
            JsonConvert.SerializeObject(
                Result.Failure(message),
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
    }

    private static string FlattenException(Exception ex)
    {
        var sb = new StringBuilder();
        int depth = 0;
        while (ex != null!)
        {
            sb.AppendLine($"[{depth}] {ex.GetType().FullName}: {ex.Message}");
            sb.AppendLine(ex.StackTrace);
            ex = ex.InnerException!;
            depth++;
        }
        return sb.ToString();
    }
}
