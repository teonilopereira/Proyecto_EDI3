using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.Trabajador
{
    public class TrabajadorResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get;  set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cargo { get; set; }
        public string TipoContrato { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal SueldoMensual { get; set; }
        public bool ViveEnLaPropiedad { get; set; }
        public int PropiedadAgricolaId { get; set; }
    }
}
