using Elsekily.Application.Common.Models;

namespace Elsekily.Application.Common.Interfaces.Common;

public interface IUserService
{
    public CurrentUser GetCurrentUserData();
}
