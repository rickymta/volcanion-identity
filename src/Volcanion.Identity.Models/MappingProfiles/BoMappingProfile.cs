using AutoMapper;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Response.BOs;

namespace Volcanion.Identity.Models.MappingProfiles;

public class BoMappingProfile : Profile
{
    public BoMappingProfile()
    {
        CreateMap<Account, AccountResponseBO>();

        CreateMap<Role, RoleResponseBO>()
            .ReverseMap()
            .ForMember(dest => dest.RolePermissions, opt => opt.Ignore());

        CreateMap<Permission, PermissionResponseBO>()
            .ReverseMap()
            .ForMember(dest => dest.RolePermissions, opt => opt.Ignore());

        CreateMap<RolePermission, RolePermissionResponseBO>()
            .ReverseMap()
            .ForMember(dest => dest.Permission, opt => opt.Ignore());

        CreateMap<GrantPermission, GrantPermissionResponseBO>()
            .ReverseMap()
            .ForMember(dest => dest.Account, opt => opt.Ignore());
    }
}
