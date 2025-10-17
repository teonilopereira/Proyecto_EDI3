using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.Usuario
{
    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string RolGlobal { get; set; }
        public string? Telefono { get; set; }
        public DateTime UltimoAcceso { get; set; }
        public string Estado { get; set; }
    }
}
