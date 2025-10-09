using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly ILogger<UbicacionesController> _logger;
        private readonly IApplication<Ubicacion> _ubicacion;
        public UbicacionesController(ILogger<UbicacionesController> logger, IApplication<Ubicacion> ubicacion)
        {
            _logger = logger;
            _ubicacion = ubicacion;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_ubicacion.GetAll());
        }
        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Ubicacion ubicacion = _ubicacion.GetById(Id.Value);
            if (ubicacion is null)
            {
                return NotFound();
            }
            return Ok(ubicacion);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _ubicacion.Save(ubicacion);
            return Ok(ubicacion.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, Ubicacion ubicacion)
        {
            if (!Id.HasValue){return BadRequest();}
            if(!ModelState.IsValid){return BadRequest(ModelState);}
            Ubicacion ubicacionBack = _ubicacion.GetById(Id.Value);
            if (ubicacionBack is null){return NotFound();}
            ubicacionBack.Direccion = ubicacion.Direccion;
            ubicacionBack.Localidad = ubicacion.Localidad;
            ubicacionBack.Provincia = ubicacion.Provincia;
            ubicacionBack.CodigoPostal = ubicacion.CodigoPostal;
            _ubicacion.Save(ubicacionBack);
            return Ok(ubicacionBack);
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Ubicacion ubicacionBack = _ubicacion.GetById(Id.Value);
            if (ubicacionBack is null)
            {return NotFound();}
            _ubicacion.Delete(ubicacionBack.Id);
            return Ok();
        }
    }
}
