using AutoMapper;
using GestionPropiedadesAgricolas.Application.Dtos.Trabajador;
using GestionPropiedadesAgricolas.Entities;

namespace GestionPropiedadesAgricolas.WebApi.Mapping
{
    public class TrabajadorMappingProfile:Profile
    {
        public TrabajadorMappingProfile()
        {
            CreateMap<Trabajador, TrabajadorResponseDto>()
                .ForMember(dest => dest.FechaNacimiento,
                    ori => ori.MapFrom(src => src.FechaNacimiento.ToShortDateString()));

            CreateMap<TrabajadorRequestDto, Trabajador>();
        }
    }
}
