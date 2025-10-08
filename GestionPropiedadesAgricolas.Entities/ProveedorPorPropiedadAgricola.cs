using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Entities
{
    public class ProveedorPorPropiedadAgricola
    {
        public int Id { get; set; }
        [ForeignKey(nameof(PropiedadAgricola))]
        public int PropiedadAgricolaId { get; set; }
        public virtual PropiedadAgricola PropiedadAgricola { get; set; }
        [ForeignKey(nameof(Proveedor))]

        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }

        public DateTime FechaContrato { get; set; }
        public string TipoServicio { get; set; }
    }
}
