using GestionPropiedadesAgricolas.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionPropiedadesAgricolas.Entities
{
    public class Cultivo : IEntidad
    {
        public Cultivo()
        {
            CultivosPorParcelas = new HashSet<CultivoPorParcela>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Especie { get; set; }
        [StringLength(50)]
        public string? Variedad { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaSiembra { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaEstimadaCosecha { get; set; }

        [StringLength(30)]
        public string EstadoCultivo { get; set; }
        #region Virtual
        public virtual ICollection<CultivoPorParcela> CultivosPorParcelas { get; set; }
        #endregion

    }
}
