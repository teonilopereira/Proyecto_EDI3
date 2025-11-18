using AutoMapper;
using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Parcela;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelasController : ControllerBase
    {
        private readonly ILogger<ParcelasController> _logger;
        private readonly IApplication<Parcela> _parcela;
        private readonly IMapper _mapper;
        public ParcelasController(ILogger<ParcelasController> logger, IApplication<Parcela> parcela, IMapper mapper)
        {
            _logger = logger;
            _parcela = parcela;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Administrador,Usuario")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ParcelaResponseDto>>(_parcela.GetAll()));
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
            Parcela parcela = _parcela.GetById(Id.Value);

            if (parcela is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ParcelaResponseDto>(parcela));
        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Crear(ParcelaRequestDto parcelaRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parcela = _mapper.Map<Parcela>(parcelaRequestDto);
            _parcela.Save(parcela);
            return Ok(parcela.Id);
        }
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar(int? Id, ParcelaRequestDto parcelaRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Parcela parcelaBack = _parcela.GetById(Id.Value);
            if (parcelaBack is null)
            { return NotFound(); }
            parcelaBack = _mapper.Map<Parcela>(parcelaRequestDto);
            _parcela.Save(parcelaBack);
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
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            Parcela parcelaBack = _parcela.GetById(Id.Value);
            if (parcelaBack is null)
            {
                return NotFound();
            }
            _parcela.Delete(parcelaBack.Id);
            return Ok();
        }
    }
}
