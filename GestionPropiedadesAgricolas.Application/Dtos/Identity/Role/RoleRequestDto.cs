using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.Identity.Role
{
    public class RoleRequestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
