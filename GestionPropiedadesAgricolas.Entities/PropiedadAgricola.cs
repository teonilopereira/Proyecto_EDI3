using GestionPropiedadesAgricolas.Abstactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPropiedadesAgricolas.Entities
{
    public class PropiedadAgricola:IEntidad
    {
        public PropiedadAgricola()
        {
            ProveedoresPorPropiedadesAgricolas=new HashSet<ProveedorPorPropiedadAgricola>();
            Parcelas = new HashSet<Parcela>();
            Trabajadores = new HashSet<Trabajador>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(100)]

        public double Superficie { get; set; }

        [StringLength(30)]
        public string TipoSuelo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaAdquisicion { get; set; }

        [StringLength(20)]
        public string Estado { get; set; }
        public int PropietarioId { get; set; }
        public virtual Propietario Propietario { get; set; }
        public int UbicacionId { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
        public virtual ICollection<ProveedorPorPropiedadAgricola> ProveedoresPorPropiedadesAgricolas { get; set; }
        public virtual ICollection<Parcela> Parcelas { get; set; }
        public virtual ICollection<Trabajador> Trabajadores { get; set; }


    }
}
