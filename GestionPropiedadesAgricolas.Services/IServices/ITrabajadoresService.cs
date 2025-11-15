using GestionPropiedadesAgricolas.Application.Dtos.Trabajador;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Services.IServices
{
    public interface ITrabajadoresService
    {
        Task<IList<TrabajadorResponseDto>> GetAll();
        Task<TrabajadorResponseDto?> GetById(int id);
        Task<int> Crear(TrabajadorRequestDto dto, User usuario);
        Task<bool> Editar(int id, TrabajadorRequestDto dto, User usuario);
        Task<bool> Borrar(int id, User usuario);
    }
}
