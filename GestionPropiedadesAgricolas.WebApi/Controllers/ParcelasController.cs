using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelasController : ControllerBase
    {
        private readonly ILogger<ParcelasController> _logger;
        private readonly IApplication<Parcela> _parcela;
        public ParcelasController(ILogger<ParcelasController> logger, IApplication<Parcela> parcela)
        {
            _logger = logger;
            _parcela = parcela;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_parcela.GetAll());
        }
        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Parcela parcela = _parcela.GetById(Id.Value);

            if (parcela is null)
            {
                return NotFound();
            }
            return Ok(parcela);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Parcela parcela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _parcela.Save(parcela);
            return Ok(parcela.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, Parcela parcela)
        {
            if (!Id.HasValue){return BadRequest();}
            if (!ModelState.IsValid){return BadRequest(ModelState);}
            Parcela parcelaBack = _parcela.GetById(Id.Value);
            if (parcelaBack is null){return NotFound();}
            parcelaBack.PropiedadAgricolaId = parcela.PropiedadAgricolaId;
            parcelaBack.CodigoParcela = parcela.CodigoParcela;
            parcelaBack.Superficie = parcela.Superficie;
            parcelaBack.Nombre = parcela.Nombre;
            parcelaBack.UsoActual = parcela.UsoActual;
            _parcela.Save(parcelaBack);
            return Ok(parcelaBack);
        }
        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Parcela parcelaBack = _parcela.GetById(Id.Value);
            if (parcelaBack is null)
            {
                return NotFound();
            }
            _parcela.Delete(parcelaBack.Id);
            return Ok();
        }
    }
}
