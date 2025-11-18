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
    public class Parcela : IEntidad, IClassMethods
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
        public string Nombre { get; set; }

        [StringLength(30)]
        public string UsoActual { get; set; }

        public virtual ICollection<CultivoPorParcela> CultivosPorParcelas { get; set; }
        #region setters y getters
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del autor no puede estar vacío.");
            Nombre = nombre;
        }
        public string GetName()
        {
            return string.Join(": ", this.GetName(), Nombre);
        }

        public string GetClassName()
        {
            return string.Join(": ", this.GetType().BaseType.Name, Nombre);
        }
        #endregion
    }
}
