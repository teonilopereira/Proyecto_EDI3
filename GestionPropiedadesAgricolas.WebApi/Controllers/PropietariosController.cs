using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropietariosController : ControllerBase
    {
        private readonly ILogger<PropietariosController> _logger;
        private readonly IApplication<Propietario> _propietario;
        public PropietariosController(ILogger<PropietariosController> logger, IApplication<Propietario> propietario)
        {
            _logger = logger;
            _propietario = propietario;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_propietario.GetAll());
        }
        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Propietario propietario = _propietario.GetById(Id.Value);
            if (propietario is null)
            {
                return NotFound();
            }
            return Ok(propietario);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Propietario propietario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _propietario.Save(propietario);
            return Ok(propietario.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, Propietario propietario)
        {
            if (!Id.HasValue){return BadRequest();}
            if (!ModelState.IsValid){return BadRequest(ModelState);}
            Propietario propietarioBack = _propietario.GetById(Id.Value);
            if (propietarioBack is null){return NotFound();}
            propietarioBack.NombreCompleto = propietario.NombreCompleto;
            propietarioBack.TipoEntidad = propietario.TipoEntidad;
            propietarioBack.CUIT = propietario.CUIT;
            _propietario.Save(propietarioBack);
            return Ok(propietarioBack);
        }
        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue){return BadRequest();}
            Propietario propietarioBack = _propietario.GetById(Id.Value);
            if (propietarioBack is null){return NotFound();}
            _propietario.Delete(propietarioBack.Id);
            return Ok();
        }
    }

}
