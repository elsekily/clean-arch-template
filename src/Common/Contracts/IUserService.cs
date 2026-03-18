using Elsekily.Domain.Common;

namespace Elsekily.Common.Contracts;

public interface IUserService
{
    AppUser GetCurrentUserData();
    void SetScopeUser(AppUser appUser);
}
