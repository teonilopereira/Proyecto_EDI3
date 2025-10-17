using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.Proveedor
{
    public class ProveedorRequestDto
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string TipoEntidad { get; set; }
        public string CUIT { get; set; }
        [StringLength(50)]
        public string Rubro { get; set; }
        [StringLength(150), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telefono { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }
    }
}
