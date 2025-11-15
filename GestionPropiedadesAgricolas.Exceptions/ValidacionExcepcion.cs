using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Exceptions
{
    public class ValidacionExcepcion : ExcepcionDeDominio
    {
        public IEnumerable<string> Errores { get; }

        public ValidacionExcepcion(IEnumerable<string> errores)
            : base("Error de validación")
        {
            Errores = errores;
        }
    }
}
