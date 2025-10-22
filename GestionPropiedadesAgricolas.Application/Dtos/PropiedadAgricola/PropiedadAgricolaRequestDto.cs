using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.PropiedadAgricola
{
    public class PropiedadAgricolaRequestDto
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public double Superficie { get; set; }
        [StringLength(30)]
        public string TipoSuelo { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaAdquisicion { get; set; }
        [StringLength(20)]
        public string Estado { get; set; }
        public int IdPropietarioId { get; set; }
        public int UbicacionId { get; set; }
    }
}
