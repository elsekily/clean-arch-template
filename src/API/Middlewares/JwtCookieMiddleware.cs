namespace Elsekily.API.Middlewares;

/// <summary>
/// Reads the JWT from the X-Access-Token cookie and injects it as a Bearer Authorization header.
/// This allows the API to work with cookie-based auth alongside header-based auth.
/// </summary>
public class JwtCookieMiddleware
{
    private readonly RequestDelegate _next;

    public JwtCookieMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Cookies["X-Access-Token"];

        if (!string.IsNullOrEmpty(token) && !context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Request.Headers.Append("Authorization", $"Bearer {token}");
        }

        await _next(context);
    }
}
