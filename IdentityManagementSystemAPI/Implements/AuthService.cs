using System;
using IdentityManagementSystemAPI.Core.DTOs;
using IdentityManagementSystemAPI.Core.Extensions;
using IdentityManagementSystemAPI.Core.Results;
using IdentityManagementSystemAPI.Services;
using Microsoft.AspNetCore.Identity;

namespace IdentityManagementSystemAPI.Implements;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
    }

    public async Task<IDataResult<LoginDto>> LoginAsync(string usernameOrEmail, string password, int tokenLifeTimeSecond)
    {
        var user = await _userManager.FindByUserNameOrEmail(usernameOrEmail);
        if (user is not null)
        {
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (signInResult.Succeeded)
            {
                var token = _tokenHandler.CreateAccessToken(tokenLifeTimeSecond, user);
                LoginDto responseData = new() { Token = token };
                return new SuccessDataResult<LoginDto>(responseData, Messages.UserLoginSuccessful);
            }
            return new ErrorDataResult<LoginDto>(Messages.UserLoginIncorrect);
        }
        return new ErrorDataResult<LoginDto>(Messages.UserNotFound);
    }
}
