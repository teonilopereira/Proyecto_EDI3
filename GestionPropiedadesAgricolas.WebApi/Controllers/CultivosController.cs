using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CultivosController : ControllerBase
    {
        private readonly ILogger<CultivosController> _logger;
        private readonly IApplication<Cultivo> _cultivo;
        public CultivosController(ILogger<CultivosController> logger, IApplication<Cultivo> cultivo)
        {
            _logger = logger;
            _cultivo = cultivo;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_cultivo.GetAll());
        }
        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Cultivo cultivo = _cultivo.GetById(Id.Value);
            if (cultivo is null)
            {
                return NotFound();
            }
            return Ok(cultivo);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Cultivo cultivo)
        {
            if (!ModelState.IsValid)
            {return BadRequest(ModelState);}
            _cultivo.Save(cultivo);
            return Ok(cultivo.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, Cultivo cultivo)
        {
            if (!Id.HasValue){return BadRequest();}
            if (!ModelState.IsValid){return BadRequest(ModelState);}
            Cultivo cultivoBack = _cultivo.GetById(Id.Value);
            if (cultivoBack is null){return NotFound();}
            cultivoBack.Especie = cultivo.Especie;
            cultivoBack.Variedad = cultivo.Variedad;
            cultivoBack.FechaSiembra = cultivo.FechaSiembra;
            cultivoBack.FechaEstimadaCosecha = cultivo.FechaEstimadaCosecha;
            cultivoBack.EstadoCultivo = cultivo.EstadoCultivo;
            _cultivo.Save(cultivoBack);
            return Ok(cultivoBack);
        }
        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue){return BadRequest();}
            if (!ModelState.IsValid) { return BadRequest(); }
            Cultivo cultivoBack = _cultivo.GetById(Id.Value);
            if (cultivoBack is null){return NotFound();}
            _cultivo.Delete(cultivoBack.Id);
            return Ok();
        }
    }
}
