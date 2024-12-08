using System;

namespace IdentityManagementSystemAPI.Core.Requests;

public class CreateUserRequestModel
{
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
}
