using Microsoft.Extensions.DependencyInjection;
using Volcanion_Identity_Services.Abstractions;
using Volcanion_Identity_Services.Implementations;

namespace Volcanion_Identity_Services;

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
