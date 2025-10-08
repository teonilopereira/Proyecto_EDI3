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
    public class CultivoPorParcela : IEntidad
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Cultivo))]
        public int CultivoId { get; set; }
        public virtual Cultivo Cultivo { get; set; }

        [ForeignKey(nameof(Parcela))]
        public int ParcelaId { get; set; }
        public virtual Parcela Parcela { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaSiembra { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaCosecha { get; set; }
    }
}
