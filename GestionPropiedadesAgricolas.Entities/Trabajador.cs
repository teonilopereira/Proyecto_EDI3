using GestionPropiedadesAgricolas.Abstactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPropiedadesAgricolas.Entities
{
    public class Trabajador : IEntidad
    {
        public Trabajador()
        {
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }

        [StringLength(8)]
        public string DNI { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(50)]
        public string Cargo { get; set; }

        [StringLength(30)]
        public string TipoContrato { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SueldoMensual { get; set; }

        public bool ViveEnLaPropiedad { get; set; }

        [ForeignKey(nameof(PropiedadAgricola))]
        public int PropiedadAgricolaId { get; set; }
        public virtual PropiedadAgricola PropiedadAgricola { get; set; }


        #region setters y getters
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del Trabajador no puede estar vacío.");
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido  del Trabajador no puede estar vacío.");
            Apellido = apellido;
        }
        public void SetEmail(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail) || (!mail.Contains("@") && !mail.Contains(".com")))
                throw new ArgumentException("El email del Trabajador no puede estar vacío o contener un @.");
            Email = mail;
        }

        public string GetCompleteName()
        {
            return string.Join(", ", Apellido, Nombre);
        }
        #endregion
    }
}
