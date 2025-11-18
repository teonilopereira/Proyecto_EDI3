using AutoMapper;
using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Trabajador;
using GestionPropiedadesAgricolas.Entities;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<TrabajadoresController> _logger;
        private readonly IApplication<Trabajador> _trabajador;
        private readonly IMapper _mapper;
        public TrabajadoresController(ILogger<TrabajadoresController> logger,UserManager<User>userManager, IApplication<Trabajador> trabajador, IMapper mapper)
        {
            _logger = logger;
            _trabajador = trabajador;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> All()
        {
                return Ok(_mapper.Map<IList<TrabajadorResponseDto>>(_trabajador.GetAll()));
        }
        [HttpGet]
        [Route("ById")]
        [Authorize(Roles = "Administrador")]
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
            return Ok(_mapper.Map<TrabajadorResponseDto>(trabajador));
        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Crear(TrabajadorRequestDto trabajadorRequestDto)
        {
            if (!ModelState.IsValid){return BadRequest();}
            var trabajador = _mapper.Map<Trabajador>(trabajadorRequestDto);
            _trabajador.Save(trabajador);
            return Ok(trabajador.Id);
        }
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar(int? Id, TrabajadorRequestDto trabajadorRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Trabajador trabajadorBack = _trabajador.GetById(Id.Value);
            if (trabajadorBack is null)
            { return NotFound(); }
            trabajadorBack = _mapper.Map<Trabajador>(trabajadorRequestDto);
            _trabajador.Save(trabajadorBack);
            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
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
