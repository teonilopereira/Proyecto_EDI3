using AutoMapper;
using GestionPropiedadesAgricolas.Application.Dtos.Cultivo;
using GestionPropiedadesAgricolas.Entities;
using System;
namespace GestionPropiedadesAgricolas.WebApi.Mapping
{
    public class CultivoMappingProfile : Profile
    {
        public CultivoMappingProfile()
        {
            CreateMap<Cultivo, CultivoResponseDto>()
            .ForMember(dest => dest.FechaSiembra,
                ori => ori.MapFrom(src => src.FechaSiembra.ToShortDateString()));
            CreateMap<CultivoRequestDto, Cultivo>();
        }
    }
}
