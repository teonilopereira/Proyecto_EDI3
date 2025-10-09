using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionPropiedadesAgricolas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class UsuariosController : ControllerBase
        {
            private readonly ILogger<UsuariosController> _logger;
            private readonly IApplication<Usuario> _usuario;

            public UsuariosController(ILogger<UsuariosController> logger, IApplication<Usuario> usuario)
            {
                _logger = logger;
                _usuario = usuario;
            }

            [HttpGet]
            [Route("All")]
            public async Task<IActionResult> All()
            {
                return Ok(_usuario.GetAll());
            }

            [HttpGet]
            [Route("ById")]
            public async Task<IActionResult> ById(int? Id)
            {
                if (!Id.HasValue)
                {
                    return BadRequest();
                }

                Usuario usuario = _usuario.GetById(Id.Value);

                if (usuario is null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }

            [HttpPost]
            public async Task<IActionResult> Crear(Usuario usuario)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _usuario.Save(usuario);
                return Ok(usuario.Id);
            }

            [HttpPut]
            public async Task<IActionResult> Editar(int? Id, Usuario usuario)
            {
                if (!Id.HasValue)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Usuario usuarioBack = _usuario.GetById(Id.Value);

                if (usuarioBack is null)
                {
                    return NotFound();
                }

                usuarioBack.Nombre = usuario.Nombre;
                usuarioBack.Email = usuario.Email;
                usuarioBack.RolGlobal = usuario.RolGlobal;
                usuarioBack.Telefono = usuario.Telefono;
                usuarioBack.UltimoAcceso = usuario.UltimoAcceso;
                usuarioBack.Estado = usuario.Estado;

                _usuario.Save(usuarioBack);
                return Ok(usuarioBack);
            }

            [HttpDelete]
            public async Task<IActionResult> Borrar(int? Id)
            {
                if (!Id.HasValue)
                {
                    return BadRequest();
                }

                Usuario usuarioBack = _usuario.GetById(Id.Value);

                if (usuarioBack is null)
                {
                    return NotFound();
                }

                _usuario.Delete(usuarioBack.Id);
                return Ok();
            }
        }
}

