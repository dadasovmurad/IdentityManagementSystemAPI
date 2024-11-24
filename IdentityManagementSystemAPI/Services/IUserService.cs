using IdentityManagementSystemAPI.Core.DTOs;
using IdentityManagementSystemAPI.Core.Results;
using IResult = IdentityManagementSystemAPI.Core.Results.IResult;

public interface IUserService
{
    Task<IResult> CreateAsync(CreateUserDto user);
    Task<IDataResult<UserDetailDto>> GetByIdAsync(string id);
    Task<IDataResult<List<ListUserDto>>> GetAllAsync();
}