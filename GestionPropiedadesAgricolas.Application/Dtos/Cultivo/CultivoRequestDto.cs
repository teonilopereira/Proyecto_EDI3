using System.ComponentModel.DataAnnotations;

namespace GestionPropiedadesAgricolas.Application.Dtos.Cultivo
{
    public class CultivoRequestDto
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Especie { get; set; }
        [StringLength(50)]
        public string? Variedad { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaSiembra { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaEstimadaCosecha { get; set; }
        [StringLength(30)]
        public string EstadoCultivo { get; set; }
    }
}
