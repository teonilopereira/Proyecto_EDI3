using AutoMapper;
using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Cultivo;
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
    public class CultivosController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CultivosController> _logger;
        private readonly IApplication<Cultivo> _cultivo;
        private readonly IMapper _mapper;
        public CultivosController(ILogger<CultivosController> logger, UserManager<User> userManager, IApplication<Cultivo> cultivo, IMapper mapper)
        {
            _logger = logger;
            _cultivo = cultivo;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Administrador , Usuario, Productor")]
        public async Task<IActionResult> All()
        {
                return Ok(_mapper.Map<IList<CultivoResponseDto>>(_cultivo.GetAll()));
        }
        [HttpGet]
        [Route("ById")]
        [Authorize(Roles = "Administrador,Productor")]
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
            return Ok(_mapper.Map<CultivoResponseDto>(cultivo));
        }
        [HttpPost]
        [Authorize(Roles = "Administrador,Productor")]
        public async Task<IActionResult> Crear(CultivoRequestDto cultivoRequestDto)
        {
            if (!ModelState.IsValid)
            {return BadRequest(ModelState);}
            var cultivo = _mapper.Map<Cultivo>(cultivoRequestDto);
            _cultivo.Save(cultivo);
            return Ok(cultivo.Id);
        }
        [HttpPut]
        [Authorize(Roles = "Administrador,Productor")]
        public async Task<IActionResult> Editar(int? Id, CultivoRequestDto cultivoRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Cultivo cultivoBack = _cultivo.GetById(Id.Value);
            if (cultivoBack is null)
            { return NotFound(); }
            cultivoBack = _mapper.Map<Cultivo>(cultivoRequestDto);
            _cultivo.Save(cultivoBack);
            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = "Administrador,Productor")]
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
