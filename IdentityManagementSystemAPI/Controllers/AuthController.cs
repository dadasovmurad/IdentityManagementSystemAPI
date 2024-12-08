using IdentityManagementSystemAPI.Core.Results;
using IdentityManagementSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {
            return GetResponseOnlyResultData(await _authService.LoginAsync(loginRequestModel.UserNameOrEmail, loginRequestModel.Password,3600));
        }
    }
}
