using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Proveedor;
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
    public class ProveedorService : IProveedorService
    {
        private readonly IApplication<Proveedor> _repo;
        private readonly UserManager<User> _userManager;

        public ProveedorService(IApplication<Proveedor> repo, UserManager<User> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }
        public async Task<IList<ProveedorResponseDto>> GetAll()
        {
            var lista = _repo.GetAll();

            return lista.Select(p => new ProveedorResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                TipoEntidad = p.TipoEntidad,
                CUIT = p.CUIT,
                Rubro = p.Rubro,
                Email = p.Email,
                Telefono = p.Telefono,
                Direccion = p.Direccion

            }).ToList();
        }
        public async Task<ProveedorResponseDto?> ObtenerPorId(int id)
        {
            var proveedor = _repo.GetById(id);
            if (proveedor == null)return null;
            return new ProveedorResponseDto
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                TipoEntidad = proveedor.TipoEntidad,
                CUIT = proveedor.CUIT,
                Rubro = proveedor.Rubro,
                Email = proveedor.Email,
                Telefono = proveedor.Telefono,
                Direccion = proveedor.Direccion
            };
        }
        public async Task<int> Crear(ProveedorRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para crear un proveedor.");
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Nombre)) errores.Add("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.CUIT)) errores.Add("El CUIT es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Email) || !dto.Email.Contains("@"))errores.Add("El email es obligatorio y debe ser válido.");
            if (string.IsNullOrWhiteSpace(dto.TipoEntidad)) errores.Add("El tipo de entidad es obligatorio.");
            if (errores.Any())throw new ValidacionExcepcion(errores);
            if (_repo.GetAll().Any(p => p.CUIT == dto.CUIT))
                throw new ValidacionExcepcion(new[] { "Ya existe un proveedor con este CUIT." });
            var proveedor = new Proveedor
            {
                Nombre = dto.Nombre,
                TipoEntidad = dto.TipoEntidad,
                CUIT = dto.CUIT,
                Rubro = dto.Rubro,
                Email = dto.Email,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion
            };

            _repo.Save(proveedor);
            return proveedor.Id;
        }
        public async Task<bool> Editar(int id, ProveedorRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para editar un proveedor.");
            var proveedor = _repo.GetById(id);
            if (proveedor == null)throw new NoEncontradoExcepcion("Proveedor no encontrado.");
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Nombre)) errores.Add("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.CUIT)) errores.Add("El CUIT es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Email) || !dto.Email.Contains("@"))errores.Add("El email es obligatorio y debe ser válido.");
            if (string.IsNullOrWhiteSpace(dto.TipoEntidad)) errores.Add("El tipo de entidad es obligatorio.");
            if (errores.Any())throw new ValidacionExcepcion(errores);
            if (_repo.GetAll().Any(p => p.Id != id && p.CUIT == dto.CUIT))throw new ValidacionExcepcion(new[] { "Ya existe otro proveedor con este CUIT." });
            proveedor.Nombre = dto.Nombre;
            proveedor.TipoEntidad = dto.TipoEntidad;
            proveedor.CUIT = dto.CUIT;
            proveedor.Rubro = dto.Rubro;
            proveedor.Email = dto.Email;
            proveedor.Telefono = dto.Telefono;
            proveedor.Direccion = dto.Direccion;
            _repo.Save(proveedor);
            return true;
        }
        public async Task<bool> Borrar(int id, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para borrar proveedores.");
            var proveedor = _repo.GetById(id);
            if (proveedor == null)throw new ValidacionExcepcion(new[] { "El proveedor no existe." });
            _repo.Delete(id);
            return true;
        }
    }

}
