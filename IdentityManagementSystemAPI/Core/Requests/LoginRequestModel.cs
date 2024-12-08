using System;

namespace IdentityManagementSystemAPI.Core.Results;

public class LoginRequestModel
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }
}
