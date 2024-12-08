using IdentityManagementSystemAPI.Implements;
using IdentityManagementSystemAPI.Services;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenHandler, TokenHandler>();
    }
}