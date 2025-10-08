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
    public class Usuario : IEntidad
    {
        public Usuario()
        {
            UsuariosPorPropiedadAgricolas = new HashSet<UsuarioPorPropiedadAgricola>();
        }
        public int Id { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(150), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(30)]
        public string RolGlobal { get; set; }
        [StringLength(25)]
        public string? Telefono { get; set; }
        public DateTime UltimoAcceso { get; set; }
        [StringLength(20)]
        public string Estado { get; set; }
        public virtual ICollection<UsuarioPorPropiedadAgricola> UsuariosPorPropiedadAgricolas { get; set; }
    }
}
