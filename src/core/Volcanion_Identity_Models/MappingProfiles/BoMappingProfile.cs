using AutoMapper;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Models.Response.BOs;

namespace Volcanion_Identity_Models.MappingProfiles;

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
