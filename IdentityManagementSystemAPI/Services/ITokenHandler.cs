using IdentityManagementSystemAPI.Core.DTOs;

namespace IdentityManagementSystemAPI.Services;

public interface ITokenHandler
{
    TokenDto CreateAccessToken(int second, AppUser user);
}
