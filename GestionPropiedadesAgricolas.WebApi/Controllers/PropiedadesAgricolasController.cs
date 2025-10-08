using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropiedadesAgricolasController : ControllerBase
    {
      //# Entidades para scaffold de AutoController:
      //- Propietario
      //- PropiedadAgrícola
      //- Parcela
      //- Cultivo
      //- Usuario
      //- Trabajador
      //- Ubicación
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PropiedadesAgricolasController> _logger;

        public PropiedadesAgricolasController(ILogger<PropiedadesAgricolasController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
