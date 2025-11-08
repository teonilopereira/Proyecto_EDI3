using AutoMapper;
using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Propietario;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class PropietariosController : ControllerBase
    {
        private readonly ILogger<PropietariosController> _logger;
        private readonly IApplication<Propietario> _propietario;
        private readonly IMapper _mapper;
        public PropietariosController(ILogger<PropietariosController> logger, IApplication<Propietario> propietario, IMapper mapper)
        {
            _logger = logger;
            _propietario = propietario;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<PropietarioResponseDto>>(_propietario.GetAll()));
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
            return Ok(_mapper.Map<PropietarioResponseDto>(propietario));
        }
        [HttpPost]
        public async Task<IActionResult> Crear(PropietarioRequestDto propietarioRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propietario = _mapper.Map<Propietario>(propietarioRequestDto);
            _propietario.Save(propietario);
            return Ok(propietario.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, PropietarioRequestDto propietarioRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Propietario propietarioBack = _propietario.GetById(Id.Value);
            if (propietarioBack is null)
            { return NotFound(); }
            propietarioBack = _mapper.Map<Propietario>(propietarioRequestDto);
            _propietario.Save(propietarioBack);
            return Ok();
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
