using GestionPropiedadesAgricolas.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Entities
{
    public class Propietario:IEntidad
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoEntidad { get; set; } 
        public string CUIT { get; set; }
    }
}
