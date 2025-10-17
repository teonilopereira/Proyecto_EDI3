using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.Ubicacion
{
    public class UbicacionRequestDto
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Direccion { get; set; }
        [StringLength(100)]
        public string Localidad { get; set; }
        [StringLength(100)]
        public string Provincia { get; set; }
        [StringLength(10)]
        public string? CodigoPostal { get; set; }
    }
}
