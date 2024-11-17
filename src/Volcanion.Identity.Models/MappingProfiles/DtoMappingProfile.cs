using AutoMapper;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request.DTOs;

namespace Volcanion.Identity.Models.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<AccountRequestDTO, Account>();
        CreateMap<PermissionRequestDTO, Permission>();
        CreateMap<GrantPermissionRequestDTO, GrantPermission>();
        CreateMap<RolePermissionRequestDTO, RolePermission>();
        CreateMap<RoleRequestDTO, Role>();
    }
}
