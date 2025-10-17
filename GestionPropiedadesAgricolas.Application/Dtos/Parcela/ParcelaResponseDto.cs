using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Application.Dtos.Parcela
{
    public class ParcelaResponseDto
    {
        public int Id { get; set; }
        public int PropiedadAgricolaId { get; set; }
        public string CodigoParcela { get; set; }
        public double Superficie { get; set; }
        public string? Nombre { get; set; }
        public string UsoActual { get; set; }
    }
}
