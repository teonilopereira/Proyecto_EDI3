using AutoMapper;
using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Ubicacion;
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
    public class UbicacionesController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UbicacionesController> _logger;
        private readonly IApplication<Ubicacion> _ubicacion;
        private readonly IMapper _mapper;
        public UbicacionesController(ILogger<UbicacionesController> logger, IApplication<Ubicacion> ubicacion, IMapper mapper, UserManager<User> userManager)
        {
            _logger = logger;
            _ubicacion = ubicacion;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Administrador,Usuario")]
        public async Task<IActionResult> All()
        {
 
                return Ok(_mapper.Map<IList<UbicacionResponseDto>>(_ubicacion.GetAll()));

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
            Ubicacion ubicacion = _ubicacion.GetById(Id.Value);
            if (ubicacion is null)
            {
                return NotFound();
            }
            var id = User.FindFirst("Id").Value.ToString();
            var user = _userManager.FindByIdAsync(id).Result;
            if (_userManager.IsInRoleAsync(user, "Administrador").Result)
            {
                var name = User.FindFirst("name");
                var a = User.Claims;
                return Ok(_mapper.Map<UbicacionResponseDto>(ubicacion));
            }
            return Unauthorized();
        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Crear(UbicacionRequestDto ubicacionRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ubicacion = _mapper.Map<Ubicacion>(ubicacionRequestDto);
            _ubicacion.Save(ubicacion);
            return Ok(ubicacion.Id);
        }
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar(int? Id, UbicacionRequestDto ubicacionRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Ubicacion ubicacionBack = _ubicacion.GetById(Id.Value);
            if (ubicacionBack is null)
            { return NotFound(); }
            ubicacionBack = _mapper.Map<Ubicacion>(ubicacionRequestDto);
            _ubicacion.Save(ubicacionBack);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
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
