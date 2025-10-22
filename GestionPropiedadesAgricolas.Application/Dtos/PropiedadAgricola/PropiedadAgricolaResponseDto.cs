using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.PropiedadAgricola
{
    public class PropiedadAgricolaResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Superficie { get; set; }
        public string TipoSuelo { get; set; }
        public DateTime? FechaAdquisicion { get; set; }
        public string Estado { get; set; }
        public int PropietarioId { get; set; }
        public int UbicacionId { get; set; }
    }
}
