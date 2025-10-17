using AutoMapper;
using GestionPropiedadesAgricolas.Application.Dtos.Proveedor;
using GestionPropiedadesAgricolas.Entities;

namespace GestionPropiedadesAgricolas.WebApi.Mapping
{
    public class ProveedorMappingProfile: Profile
    {
        public ProveedorMappingProfile()
        {
            CreateMap<Proveedor, ProveedorResponseDto>();
            CreateMap<ProveedorRequestDto, Proveedor>();
        }
    }
}
