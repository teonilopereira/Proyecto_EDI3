using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Exceptions
{
    public class NoEncontradoExcepcion : ExcepcionDeDominio
    {
        public NoEncontradoExcepcion(string mensaje) : base(mensaje) { }
    }
}
