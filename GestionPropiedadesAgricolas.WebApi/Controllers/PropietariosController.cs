using AutoMapper;
using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Propietario;
using GestionPropiedadesAgricolas.Entities;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using GestionPropiedadesAgricolas.Exceptions;
using GestionPropiedadesAgricolas.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace GestionPropiedadesAgricolas.WebApi.Controllers
{

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [ApiController]
        public class PropietariosController : ControllerBase
        {
            private readonly UserManager<User> _userManager;
            private readonly ILogger<PropietariosController> _logger;
            private readonly IApplication<Propietario> _propietario;
            private readonly IMapper _mapper;

            public PropietariosController(
                ILogger<PropietariosController> logger,
                UserManager<User> userManager,
                IApplication<Propietario> propietario,
                IMapper mapper)
            {
                _logger = logger;
                _userManager = userManager;
                _propietario = propietario;
                _mapper = mapper;
            }
            [HttpGet]
            [Route("All")]
            [Authorize(Roles = "Administrador ")]
            public async Task<IActionResult> All()
            {

                    var lista = _propietario.GetAll();
                    return Ok(_mapper.Map<IList<PropietarioResponseDto>>(lista));

            }
            [HttpGet]
            [Route("ById")]
            [Authorize(Roles = "Administrador")]
            public IActionResult ById(int? Id)
            {
                if (!Id.HasValue)
                    return BadRequest();

                var propietario = _propietario.GetById(Id.Value);
                if (propietario is null)
                    return NotFound();

                return Ok(_mapper.Map<PropietarioResponseDto>(propietario));
            }
            [HttpPost]
            [Authorize(Roles = "Administrador")]
            public IActionResult Crear([FromBody] PropietarioRequestDto propietarioDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var propietario = _mapper.Map<Propietario>(propietarioDto);

                _propietario.Save(propietario);

                return Ok(propietario.Id);
            }
            [HttpPut]
            [Authorize(Roles = "Administrador")]
            public IActionResult Editar(int? Id, [FromBody] PropietarioRequestDto propietarioDto)
            {
                if (!Id.HasValue)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var propietarioBack = _propietario.GetById(Id.Value);
                if (propietarioBack is null)
                    return NotFound();

                propietarioBack = _mapper.Map<Propietario>(propietarioDto);
                propietarioBack.Id = Id.Value;

                _propietario.Save(propietarioBack);

                return Ok();
            }
            [HttpDelete]
            [Authorize(Roles = "Administrador")]
            public IActionResult Borrar(int? Id)
            {
                if (!Id.HasValue)
                    return BadRequest();

                var propietario = _propietario.GetById(Id.Value);
                if (propietario is null)
                    return NotFound();

                _propietario.Delete(propietario.Id);

                return Ok();
            }
        }
    }

