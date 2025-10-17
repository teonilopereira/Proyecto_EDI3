using AutoMapper;
using GestionPropiedadesAgricolas.Application.Dtos.PropiedadAgricola;
using GestionPropiedadesAgricolas.Entities;

namespace GestionPropiedadesAgricolas.WebApi.Mapping
{
    public class PropiedadAgricolaMappingProfile:Profile
    {
        public PropiedadAgricolaMappingProfile()
        {
            CreateMap<PropiedadAgricola, PropiedadAgricolaResponseDto>()
                .ForMember(dest => dest.Nombre,
                ori => ori.MapFrom(src => src.Nombre));

            CreateMap<PropiedadAgricolaRequestDto, PropiedadAgricola>();
        }

    }
}
