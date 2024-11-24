using Microsoft.AspNetCore.Mvc;
using Result = IdentityManagementSystemAPI.Core.Results;
[Route("[controller]")]
[ApiController]
public class BaseApiController : Controller
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponseOnlyResult(Result.IResult result)
    {
        return result.Success ? Ok(result) : BadRequest(result);
    }
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponseOnlyResultData<T>(Result.IDataResult<T> result)
    {
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }
}
