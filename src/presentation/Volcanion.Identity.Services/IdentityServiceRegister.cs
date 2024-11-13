using Microsoft.Extensions.DependencyInjection;
using Volcanion.Identity.Services.Abstractions;
using Volcanion.Identity.Services.Implementations;

namespace Volcanion.Identity.Services;

/// <summary>
/// IdentityInfrastructureRegister
/// </summary>
public static class IdentityServiceRegister
{
    /// <summary>
    /// RegisterIdentityInfrastructure
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterIdentityService(this IServiceCollection services)
    {
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<IGrantPermissionService, GrantPermissionService>();
        services.AddTransient<IPermissionService, PermissionService>();
        services.AddTransient<IRolePermissionService, RolePermissionService>();
        services.AddTransient<IRoleService, RoleService>();
    }
}
