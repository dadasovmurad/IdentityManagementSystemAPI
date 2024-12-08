using System;
using Microsoft.AspNetCore.Identity;

namespace IdentityManagementSystemAPI.Core.Extensions;

public static class UserExtensions
{
    public async static Task<TUser>? FindByUserNameOrEmail<TUser>(this UserManager<TUser> userManager, string userNameOrEmail) where TUser : class
    {
        if (string.IsNullOrEmpty(userNameOrEmail))
        {
            return null;
        }
        return await userManager.FindByNameAsync(userNameOrEmail) 
            ?? await userManager.FindByEmailAsync(userNameOrEmail);
    }
}
