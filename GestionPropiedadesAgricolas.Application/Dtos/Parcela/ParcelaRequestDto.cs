using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPropiedadesAgricolas.Application.Dtos.Parcela
{
    public class ParcelaRequestDto
    {
        public int Id { get; set; }
        [ForeignKey(nameof(PropiedadAgricola))]
        public int PropiedadAgricolaId { get; set; }
        [StringLength(30)]
        public string CodigoParcela { get; set; }
        [StringLength(100)]
        public double Superficie { get; set; }
        [StringLength(50)]
        public string? Nombre { get; set; }
        [StringLength(30)]
        public string UsoActual { get; set; }

    }
}
