using GestionPropiedadesAgricolas.Application.Dtos.Proveedor;
using GestionPropiedadesAgricolas.Application.Dtos.Trabajador;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Services.IServices
{
    public interface IProveedorService
    {
        Task<IList<ProveedorResponseDto>> GetAll();
        Task<ProveedorResponseDto?> ObtenerPorId(int id);
        Task<int> Crear(ProveedorRequestDto dto, User usuario);
        Task<bool> Editar(int id, ProveedorRequestDto dto, User usuario);
        Task<bool> Borrar(int id, User usuario);
    }
}
