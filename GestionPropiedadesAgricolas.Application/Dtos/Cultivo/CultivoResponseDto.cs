namespace GestionPropiedadesAgricolas.Application.Dtos.Cultivo
{
    public class CultivoResponseDto
    {

        public int Id { get; set; }
        public string Especie { get; set; }
        public string? Variedad { get; set; }
        public DateTime FechaSiembra { get; set; }
        public DateTime? FechaEstimadaCosecha { get; set; }
        public string EstadoCultivo { get; set; }
    }
}
