using GestionPropiedadesAgricolas.Application.Dtos.Propietario;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Services.IServices
{
    public interface IPropietarioService
    {
        Task<IList<PropietarioResponseDto>> GetAll(User usuario);
        Task<PropietarioResponseDto?> ObtenerPorId(int id, User usuario);
        Task<int> Crear(PropietarioRequestDto dto, User usuario);
        Task<bool> Editar(int id, PropietarioRequestDto dto, User usuario);
        Task<bool> Borrar(int id, User usuario);
    }
}
