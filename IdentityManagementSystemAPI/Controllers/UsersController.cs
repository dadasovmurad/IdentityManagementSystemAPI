using IdentityManagementSystemAPI.Core.DTOs;
using IdentityManagementSystemAPI.Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseApiController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Get(string id)
    {
        return GetResponseOnlyResultData(await _userService.GetByIdAsync(id));
    }
    [HttpGet("get-all")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        return GetResponseOnlyResultData(await _userService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequestModel createUserRequestModel)
    {
        return GetResponseOnlyResult(await _userService.CreateAsync(new()
        {
            Email = createUserRequestModel.Email,
            Name = createUserRequestModel.Name,
            Surname = createUserRequestModel.Surname,
            UserName = createUserRequestModel.UserName,
            Password = createUserRequestModel.Password
        }));
    }
}