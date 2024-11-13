using AutoMapper;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Models.Request.DTOs;

namespace Volcanion_Identity_Models.MappingProfiles;

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
