using GestionPropiedadesAgricolas.Application.Dtos.Identity.Role;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;

namespace GestionPropiedadesAgricolas.Services.IServices
{
    public interface IRoleService
    {
        Task<IList<RoleResponseDto>> GetAll(User usuario);
        Task<Guid> Crear(RoleRequestDto dto, User usuario);
        Task Editar(Guid id, RoleRequestDto dto, User usuario);
        Task<RoleResponseDto> ObtenerPorId(Guid id);
    }
}
