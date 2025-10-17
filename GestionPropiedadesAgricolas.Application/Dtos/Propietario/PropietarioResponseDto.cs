using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.Propietario
{
    public class PropietarioResponseDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoEntidad { get; set; }
        public string CUIT { get; set; }
    }
}
