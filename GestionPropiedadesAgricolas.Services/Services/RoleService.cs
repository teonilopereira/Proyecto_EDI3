using GestionPropiedadesAgricolas.Application.Dtos.Identity.Role;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using GestionPropiedadesAgricolas.Exceptions;
using GestionPropiedadesAgricolas.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace GestionPropiedadesAgricolas.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleService(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IList<RoleResponseDto>> GetAll(User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para ver roles");
            return _roleManager.Roles.Select(r => new RoleResponseDto { Id = r.Id, Name = r.Name }).ToList();
        }
        public async Task<Guid> Crear(RoleRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para crear roles");
            var role = new Role { Id = Guid.NewGuid(), Name = dto.Name };
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
                throw new ValidacionExcepcion(result.Errors.Select(e => e.Description));
            return role.Id;
        }
        public async Task Editar(Guid id, RoleRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para editar roles");
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null) throw new NoEncontradoExcepcion("Rol no encontrado");
            role.Name = dto.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)throw new ValidacionExcepcion(result.Errors.Select(e => e.Description));
        }
        public async Task<RoleResponseDto> ObtenerPorId(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)throw new NoEncontradoExcepcion("Rol no encontrado");
            return new RoleResponseDto { Id = role.Id, Name = role.Name };
        }
    }
}
