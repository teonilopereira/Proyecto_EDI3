using GestionPropiedadesAgricolas.Application.Dtos.Parcela;
using GestionPropiedadesAgricolas.Entities;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Services.IServices
{
    public interface IParcelaService
    {
        Task<IList<ParcelaResponseDto>> GetAll(User usuario);
        Task<ParcelaResponseDto> ObtenerPorId(int id);
        Task<int> Crear(ParcelaRequestDto parcela, User usuario);
        Task Editar(int id, ParcelaRequestDto parcela, User usuario);
        Task Borrar(int id, User usuario);
    }
}
