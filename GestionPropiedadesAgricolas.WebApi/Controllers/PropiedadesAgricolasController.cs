using AutoMapper;
using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.PropiedadAgricola;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadesAgricolasController : ControllerBase
    {

        private readonly ILogger<PropiedadesAgricolasController> _logger;
        private readonly IApplication<PropiedadAgricola> _propiedadAgricola;
        private readonly IMapper _mapper;
        public PropiedadesAgricolasController(ILogger<PropiedadesAgricolasController> logger, IApplication<PropiedadAgricola> propiedadAgricola, IMapper mapper)
        {
            _logger = logger;
            _propiedadAgricola = propiedadAgricola;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Administrador,Usuario,Productor")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<PropiedadAgricolaResponseDto>>(_propiedadAgricola.GetAll()));
        }
        [HttpGet]
        [Route("ById")]
        [Authorize(Roles = "Administrador,,Productor")]
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
            return Ok(_mapper.Map<PropiedadAgricolaResponseDto>(propiedadAgricola));
        }
        [HttpPost]
        [Authorize(Roles = "Administrador,Productor")]
        public async Task<IActionResult> Crear(PropiedadAgricolaRequestDto propiedadAgricolaRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var propiedadAgricola = _mapper.Map<PropiedadAgricola>(propiedadAgricolaRequestDto);
            _propiedadAgricola.Save(propiedadAgricola);
            return Ok(propiedadAgricola.Id);
        }
        [HttpPut]
        [Authorize(Roles = "Administrador,Productor")]
        public async Task<IActionResult> Editar(int? Id, PropiedadAgricolaRequestDto propiedadAgricolaRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            PropiedadAgricola propiedadAgricolaBack = _propiedadAgricola.GetById(Id.Value);
            if (propiedadAgricolaBack is null)
            { return NotFound(); }
            propiedadAgricolaBack = _mapper.Map<PropiedadAgricola>(propiedadAgricolaRequestDto);
            _propiedadAgricola.Save(propiedadAgricolaBack);
            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = "Administrador,Productor")]
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
