using IdentityManagementSystemAPI.Core.DTOs;
using IdentityManagementSystemAPI.Core.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IResult = IdentityManagementSystemAPI.Core.Results.IResult;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IResult> CreateAsync(CreateUserDto user)
    {
        var identityResult = await _userManager.CreateAsync(new()
        {
            Email = user.Email,
            UserName = user.UserName,
            Name = user.Name,
            Surname = user.Surname
        }, user.Password);

        if (identityResult.Succeeded)
        {
            return new SuccessResult(Messages.UserCreateSuccessful);
        }
        return new ErrorResult(identityResult.ToErrorString());
    }

    public async Task<IDataResult<List<ListUserDto>>> GetAllAsync()
    {
        var users = await _userManager.Users.Select(user => new ListUserDto
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            Name = user.Name,
            Surname = user.Surname
        }).ToListAsync();

        return new SuccessDataResult<List<ListUserDto>>(users);
    }

    public async Task<IDataResult<UserDetailDto>> GetByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        var userDto = new UserDetailDto
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            Name = user.Name,
            Surname = user.Surname
        };

        if (user is not null)
        {
            return new SuccessDataResult<UserDetailDto>(userDto);
        }
        return new ErrorDataResult<UserDetailDto>(Messages.UserNotFound);
    }
}