using AutoMapper;
using GestionPropiedadesAgricolas.Application.Dtos.Ubicacion;
using GestionPropiedadesAgricolas.Entities;

namespace GestionPropiedadesAgricolas.WebApi.Mapping
{
    public class UbicacionMappingProfile: Profile
    {
        public UbicacionMappingProfile()
        {
            CreateMap<Ubicacion, UbicacionResponseDto>();
            CreateMap<UbicacionRequestDto, Ubicacion>();
        }

    }
}
