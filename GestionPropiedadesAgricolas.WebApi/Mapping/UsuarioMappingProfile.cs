using AutoMapper;
using GestionPropiedadesAgricolas.Application.Dtos.Usuario;
using GestionPropiedadesAgricolas.Entities;
using System;

namespace GestionPropiedadesAgricolas.WebApi.Mapping
{
    public class UsuarioMappingProfile: Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioResponseDto>()
                .ForMember(dest => dest.UltimoAcceso,
                    ori => ori.MapFrom(src => src.UltimoAcceso.ToShortDateString()));
            CreateMap<UsuarioRequestDto, Usuario>();
        }
    }
}
