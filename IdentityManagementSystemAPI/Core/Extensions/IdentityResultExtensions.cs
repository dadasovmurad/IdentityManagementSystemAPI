using System.Text;
using IdentityManagementSystemAPI.Core.Results;
using Microsoft.AspNetCore.Identity;

public static class IdentityResultExtensions
{
    public static string ToErrorString(this IdentityResult result)
    {
        if(result.Succeeded) return string.Empty;

        StringBuilder sb = new();
        foreach(var error in result.Errors)
        {
            sb.AppendLine($"{error.Code} - {error.Description}");
        }

        return sb.ToString();
    }
}