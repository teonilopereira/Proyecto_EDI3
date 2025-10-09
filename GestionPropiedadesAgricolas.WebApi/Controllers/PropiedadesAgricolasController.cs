using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadesAgricolasController : ControllerBase
    {

        private readonly ILogger<PropiedadesAgricolasController> _logger;
        private readonly IApplication<PropiedadAgricola> _propiedadAgricola;
        public PropiedadesAgricolasController(ILogger<PropiedadesAgricolasController> logger, IApplication<PropiedadAgricola> propiedadAgricola)
        {
            _logger = logger;
            _propiedadAgricola = propiedadAgricola;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_propiedadAgricola.GetAll());
        }
        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            PropiedadAgricola propiedadAgricola = _propiedadAgricola.GetById(Id.Value);
            if (propiedadAgricola is null)
            {
                return NotFound();
            }
            return Ok(propiedadAgricola);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(PropiedadAgricola propiedadAgricola)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            _propiedadAgricola.Save(propiedadAgricola);
            return Ok(propiedadAgricola.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, PropiedadAgricola propiedadAgricola)
        {
            if (!Id.HasValue){return BadRequest();}
            if (!ModelState.IsValid){ return BadRequest(ModelState);}
            PropiedadAgricola propiedadBack = _propiedadAgricola.GetById(Id.Value);
            if (propiedadBack is null){return NotFound();}
            propiedadBack.Nombre = propiedadAgricola.Nombre;
            propiedadBack.Superficie = propiedadAgricola.Superficie;
            propiedadBack.TipoSuelo = propiedadAgricola.TipoSuelo;
            propiedadBack.FechaAdquisicion = propiedadAgricola.FechaAdquisicion;
            propiedadBack.Estado = propiedadAgricola.Estado;
            propiedadBack.IdPropietario = propiedadAgricola.IdPropietario;
            propiedadBack.IdUbicacion = propiedadAgricola.IdUbicacion;
            _propiedadAgricola.Save(propiedadBack);
            return Ok(propiedadBack);
        }
        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue){ return BadRequest();}
            if (!ModelState.IsValid){return BadRequest();}
            PropiedadAgricola propiedadBack = _propiedadAgricola.GetById(Id.Value);
            if (propiedadBack is null)
            { return NotFound(); }
            _propiedadAgricola.Delete(propiedadBack.Id);
            return Ok();
        }

    }
}
