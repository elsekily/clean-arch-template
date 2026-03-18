namespace Elsekily.Domain.Common;

/// <summary>
/// Represents the authenticated user principal passed through the application.
/// </summary>
public class AppUser
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new();
}
