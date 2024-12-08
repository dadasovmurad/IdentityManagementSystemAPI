using System;
using IdentityManagementSystemAPI.Core.DTOs;
using IdentityManagementSystemAPI.Core.Results;

namespace IdentityManagementSystemAPI.Services;

public interface IAuthService
{
    Task<IDataResult<LoginDto>> LoginAsync(string usernameOrEmail,string password,int tokenLifeTimeSecond);
}
