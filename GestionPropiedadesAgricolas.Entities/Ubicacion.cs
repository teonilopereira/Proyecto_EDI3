using GestionPropiedadesAgricolas.Abstactions;
using System.ComponentModel.DataAnnotations;

namespace GestionPropiedadesAgricolas.Entities
{
    public class Ubicacion : IEntidad
    {
        public Ubicacion()
        {
            PropiedadesAgricolas = new HashSet<PropiedadAgricola>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(100)]
        public string Localidad { get; set; }

        [StringLength(100)]
        public string Provincia { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }

        public virtual ICollection<PropiedadAgricola> PropiedadesAgricolas { get; set; }
    }
}
