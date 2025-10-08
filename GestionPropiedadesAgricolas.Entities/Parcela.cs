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
    public class Parcela : IEntidad
    {
        public Parcela()
        {
            CultivosPorParcelas = new HashSet<CultivoPorParcela>();
        }

        public int Id { get; set; }

        [ForeignKey(nameof(PropiedadAgricola))]
        public int PropiedadAgricolaId { get; set; }
        public virtual PropiedadAgricola PropiedadAgricola { get; set; }

        [StringLength(30)]
        public string CodigoParcela { get; set; }
        [StringLength(100)]
        public double Superficie { get; set; }

        [StringLength(50)]
        public string? Nombre { get; set; }

        [StringLength(30)]
        public string UsoActual { get; set; }

        public virtual ICollection<CultivoPorParcela> CultivosPorParcelas { get; set; }
    }
}
