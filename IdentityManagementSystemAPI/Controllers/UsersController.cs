using IdentityManagementSystemAPI.Core.DTOs;
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
    public async Task<IActionResult> Get(string id)
    {
        return GetResponseOnlyResultData(await _userService.GetByIdAsync(id));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return GetResponseOnlyResultData(await _userService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateUserDto createUserDto)
    {
        return GetResponseOnlyResult(await _userService.CreateAsync(createUserDto));
    }
}