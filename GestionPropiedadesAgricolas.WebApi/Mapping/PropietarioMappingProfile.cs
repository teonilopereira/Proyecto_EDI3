using AutoMapper;
using GestionPropiedadesAgricolas.Application.Dtos.Propietario;
using GestionPropiedadesAgricolas.Entities;

namespace GestionPropiedadesAgricolas.WebApi.Mapping
{
    public class PropietarioMappingProfile: Profile
    {
        public PropietarioMappingProfile()
        {
            CreateMap<Propietario, PropietarioResponseDto>();
            CreateMap<PropietarioRequestDto, Propietario>();
        }
    }
}
