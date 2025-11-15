using GestionPropiedadesAgricolas.Application.Dtos.PropiedadAgricola;
using GestionPropiedadesAgricolas.Application.Dtos.Ubicacion;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Services.IServices
{
    public interface IUbicaciónService
    {
        Task<IList<UbicacionResponseDto>> GetAll();
        Task<UbicacionResponseDto?> GetById(int id);
        Task<int> Crear(UbicacionRequestDto dto);
        Task<bool> Editar(int id, UbicacionRequestDto dto);
        Task<bool> Borrar(int id, User usuario);
    }
}

