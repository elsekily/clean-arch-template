using System.Security.Claims;
using Elsekily.Application.Common.Interfaces.Common;
using Elsekily.Application.Common.Models;
using Microsoft.AspNetCore.Http;

namespace Elsekily.Infrastructure.Identity;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CurrentUser GetCurrentUserData()
    {
        var user = new CurrentUser();
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        {
            user.Id = userId;
        }

        return user;
    }
}
