using AutoMapper;
using GestionPropiedadesAgricolas.Application.Dtos.Identity.Role;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;

namespace GestionPropiedadesAgricolas.WebApi.Mapping
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleResponseDto>();
            CreateMap<RoleRequestDto, Role>();
        }
    }
}
