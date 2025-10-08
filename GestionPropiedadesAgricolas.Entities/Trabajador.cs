using GestionPropiedadesAgricolas.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Entities
{
    public class Trabajador : IEntidad
    {
        public Trabajador()
        {
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [StringLength(10)]
        public string DNI { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(50)]
        public string Cargo { get; set; }

        [StringLength(30)]
        public string TipoContrato { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SueldoMensual { get; set; }

        public bool ViveEnLaPropiedad { get; set; }

        [ForeignKey(nameof(PropiedadAgricola))]
        public int PropiedadAgricolaId { get; set; }
        public virtual PropiedadAgricola PropiedadAgricola { get; set; }
    }
}
