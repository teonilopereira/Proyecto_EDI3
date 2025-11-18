using GestionPropiedadesAgricolas.Application.Dtos.Cultivo;
using GestionPropiedadesAgricolas.Entities;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Services.IServices
{
    public interface ICultivoService
    {
        Task<IList<CultivoResponseDto>> GetAll(User usuario);
        Task<CultivoResponseDto> ObtenerPorId(int id, User usuario);
        Task<int> Crear(CultivoRequestDto cultivo, User usuario);
        Task Editar(int id, CultivoRequestDto cultivo, User usuario);
        Task Borrar(int id, User usuario);
    }
}
