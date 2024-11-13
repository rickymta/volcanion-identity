using Microsoft.Extensions.DependencyInjection;
using Volcanion_Identity_Infrastructure.Abstractions;
using Volcanion_Identity_Infrastructure.Implementations;

namespace Volcanion_Identity_Infrastructure;

/// <summary>
/// IdentityInfrastructureRegister
/// </summary>
public static class IdentityInfrastructureRegister
{
    /// <summary>
    /// RegisterIdentityInfrastructure
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterIdentityInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<IGrantPermissionRepository, GrantPermissionRepository>();
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddTransient<IPermissionRepository, PermissionRepository>();
        services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
    }
}
