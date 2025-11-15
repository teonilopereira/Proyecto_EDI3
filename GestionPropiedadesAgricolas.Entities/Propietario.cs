using GestionPropiedadesAgricolas.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionPropiedadesAgricolas.Entities
{
    public class Propietario:IEntidad, IClassMethods
    {
        #region Properties
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoEntidad { get; set; } 
        public string CUIT { get; set; }
        #endregion
        #region setters y getters
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del autor no puede estar vacío.");
            NombreCompleto = nombre;
        }
        public string GetClassName()
        {
            return string.Join(": ", this.GetType().BaseType.Name, NombreCompleto);
        }
        #endregion
    }
}
