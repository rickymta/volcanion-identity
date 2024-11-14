using AutoMapper;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request.DTOs;

namespace Volcanion.Identity.Models.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<Account, AccountRequestDTO>();
        CreateMap<Permission, PermissionRequestDTO>();
        CreateMap<GrantPermission, GrantPermissionRequestDTO>();
        CreateMap<RolePermission, RolePermissionRequestDTO>();
        CreateMap<Role, RoleRequestDTO>();
    }
}
