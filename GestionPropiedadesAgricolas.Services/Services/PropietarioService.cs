using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Propietario;
using GestionPropiedadesAgricolas.Entities;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using GestionPropiedadesAgricolas.Exceptions;
using GestionPropiedadesAgricolas.Services.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Services.Services
{
    public class PropietarioService : IPropietarioService
    {
        private readonly IApplication<Propietario> _repo;
        private readonly UserManager<User> _userManager;

        public PropietarioService(IApplication<Propietario> repo, UserManager<User> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }
        public async Task<IList<PropietarioResponseDto>> GetAll(User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador") &&
                !await _userManager.IsInRoleAsync(usuario, "Usuario")) throw new AccesoExcepcion("No tenés permisos para ver propietarios.");
            var lista = _repo.GetAll();
            return lista.Select(p => new PropietarioResponseDto
            {
                Id = p.Id,
                NombreCompleto = p.NombreCompleto,
                TipoEntidad = p.TipoEntidad,
                CUIT = p.CUIT

            }).ToList();
        }
        public async Task<PropietarioResponseDto?> ObtenerPorId(int id, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para ver propietarios.");
            var propietario = _repo.GetById(id);
            if (propietario == null)
                return null;
            return new PropietarioResponseDto
            {
                Id = propietario.Id,
                NombreCompleto = propietario.NombreCompleto,
                TipoEntidad = propietario.TipoEntidad,
                CUIT = propietario.CUIT
            };
        }
        public async Task<int> Crear(PropietarioRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para crear un propietario.");
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.NombreCompleto))errores.Add("El nombre completo es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.CUIT))errores.Add("El CUIT es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.TipoEntidad))errores.Add("El tipo de entidad es obligatorio.");
            if (errores.Any())throw new ValidacionExcepcion(errores);
            if (_repo.GetAll().Any(p => p.CUIT == dto.CUIT))throw new ValidacionExcepcion(new[] { "Ya existe un propietario con este CUIT." });
            var propietario = new Propietario
            {
                TipoEntidad = dto.TipoEntidad,
                CUIT = dto.CUIT
            };
            propietario.SetNombre(dto.NombreCompleto);
            _repo.Save(propietario);
            return propietario.Id;
        }
        public async Task<bool> Editar(int id, PropietarioRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para editar propietarios.");
            var propietario = _repo.GetById(id);
            if (propietario == null)throw new NoEncontradoExcepcion("Propietario no encontrado.");
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.NombreCompleto))errores.Add("El nombre completo es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.TipoEntidad))errores.Add("El tipo de entidad es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.CUIT))errores.Add("El CUIT es obligatorio.");
            if (errores.Any())
                throw new ValidacionExcepcion(errores);
            if (_repo.GetAll().Any(p => p.Id != id && p.CUIT == dto.CUIT))
                throw new ValidacionExcepcion(new[] { "Ya existe otro propietario con este CUIT." });
            propietario.TipoEntidad = dto.TipoEntidad;
            propietario.CUIT = dto.CUIT;
            propietario.SetNombre(dto.NombreCompleto);
            _repo.Save(propietario);
            return true;
        }

        public async Task<bool> Borrar(int id, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para borrar propietarios.");
            var propietario = _repo.GetById(id);
            if (propietario == null)throw new ValidacionExcepcion(new[] { "El propietario no existe." });
            _repo.Delete(id);
            return true;
        }
    }
}
