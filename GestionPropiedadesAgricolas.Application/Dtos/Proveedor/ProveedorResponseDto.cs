using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.Proveedor
{
    public class ProveedorResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoEntidad { get; set; }
        public string CUIT { get; set; }
        public string Rubro { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
