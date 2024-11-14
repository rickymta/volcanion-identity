using AutoMapper;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Response.BOs;

namespace Volcanion.Identity.Models.MappingProfiles;

public class BoMappingProfile : Profile
{
    public BoMappingProfile()
    {
        CreateMap<Account, AccountResponseBO>();
        CreateMap<Role, RoleResponseBO>();
        CreateMap<Permission, PermissionResponseBO>();
        CreateMap<RolePermission, RolePermissionResponseBO>();
        CreateMap<GrantPermission, GrantPermissionResponseBO>();
    }
}
