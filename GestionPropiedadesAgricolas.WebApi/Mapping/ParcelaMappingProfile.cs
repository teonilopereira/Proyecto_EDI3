using AutoMapper;
using GestionPropiedadesAgricolas.Application.Dtos.Parcela;
using GestionPropiedadesAgricolas.Entities;

namespace GestionPropiedadesAgricolas.WebApi.Mapping
{
    public class ParcelaMappingProfile: Profile
    {
        public ParcelaMappingProfile()
        {
            CreateMap<Parcela, ParcelaResponseDto>()
                .ForMember(dest => dest.Nombre,
                    ori => ori.MapFrom(src => src.Nombre));

            CreateMap<ParcelaRequestDto, Parcela>();
        }
    }
}
