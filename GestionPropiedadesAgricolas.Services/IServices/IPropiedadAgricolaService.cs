using GestionPropiedadesAgricolas.Application.Dtos.PropiedadAgricola;
using GestionPropiedadesAgricolas.Entities;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Services.IServices
{
    public interface IPropiedadAgricolaService
    {
            Task<IList<PropiedadAgricolaResponseDto>> GetAll(User usuario);
            Task<PropiedadAgricolaResponseDto> GetById(int id);
            Task<int> Crear(PropiedadAgricolaRequestDto dto, User usuario);
            Task Editar(int id, PropiedadAgricolaRequestDto dto);
            Task Borrar(int id, User usuario);
        }

    
}
