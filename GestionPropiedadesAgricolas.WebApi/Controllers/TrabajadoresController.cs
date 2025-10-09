using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly ILogger<TrabajadoresController> _logger;
        private readonly IApplication<Trabajador> _trabajador;
        public TrabajadoresController(ILogger<TrabajadoresController> logger, IApplication<Trabajador> trabajador)
        {
            _logger = logger;
            _trabajador = trabajador;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_trabajador.GetAll());
        }
        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Trabajador trabajador = _trabajador.GetById(Id.Value);
            if (trabajador is null)
            {
                return NotFound();
            }
            return Ok(trabajador);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Trabajador trabajador)
        {
            if (!ModelState.IsValid){return BadRequest();}
            _trabajador.Save(trabajador);
            return Ok(trabajador.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, Trabajador trabajador)
        {
            if(!Id.HasValue){return BadRequest();}
            if(!ModelState.IsValid){return BadRequest(ModelState);}
            Trabajador trabajadorBack = _trabajador.GetById(Id.Value);
            if(trabajadorBack is null){return NotFound();}
            trabajadorBack.NombreCompleto = trabajador.NombreCompleto;
            trabajadorBack.DNI = trabajador.DNI;
            trabajadorBack.FechaNacimiento = trabajador.FechaNacimiento;
            trabajadorBack.Cargo = trabajador.Cargo;
            trabajadorBack.TipoContrato = trabajador.TipoContrato;
            trabajadorBack.FechaIngreso = trabajador.FechaIngreso;
            trabajadorBack.SueldoMensual = trabajador.SueldoMensual;
            trabajadorBack.ViveEnLaPropiedad = trabajador.ViveEnLaPropiedad;
            trabajadorBack.PropiedadAgricolaId = trabajador.PropiedadAgricolaId;
            _trabajador.Save(trabajadorBack);
            return Ok(trabajadorBack);
        }
        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue){return BadRequest();}
            if (!ModelState.IsValid){return BadRequest();}
            Trabajador trabajadorBack = _trabajador.GetById(Id.Value);
            if (trabajadorBack is null){return NotFound();}
            _trabajador.Delete(trabajadorBack.Id);
            return Ok();
        }
    }
}
