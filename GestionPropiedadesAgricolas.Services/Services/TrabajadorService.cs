using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Trabajador;
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
    public class TrabajadorService : ITrabajadoresService
    {
        private readonly IApplication<Trabajador> _repo;
        private readonly UserManager<User> _userManager;

        public TrabajadorService(IApplication<Trabajador> repo, UserManager<User> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        public async Task<IList<TrabajadorResponseDto>> GetAll()
        {
            return _repo.GetAll()
                .Select(t => new TrabajadorResponseDto
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Apellido = t.Apellido,
                    DNI = t.DNI,
                    Email = t.Email,
                    FechaNacimiento = t.FechaNacimiento,
                    Cargo = t.Cargo,
                    TipoContrato = t.TipoContrato,
                    FechaIngreso = t.FechaIngreso,
                    SueldoMensual = t.SueldoMensual,
                    ViveEnLaPropiedad = t.ViveEnLaPropiedad,
                    PropiedadAgricolaId = t.PropiedadAgricolaId
                })
                .ToList();
        }
        public async Task<TrabajadorResponseDto?> GetById(int id)
        {
            var trabajador = _repo.GetById(id);
            if (trabajador is null)return null;
            return new TrabajadorResponseDto
            {
                Id = trabajador.Id,
                Nombre = trabajador.Nombre,
                Apellido = trabajador.Apellido,
                DNI = trabajador.DNI,
                Email = trabajador.Email,
                FechaNacimiento = trabajador.FechaNacimiento,
                Cargo = trabajador.Cargo,
                TipoContrato = trabajador.TipoContrato,
                FechaIngreso = trabajador.FechaIngreso,
                SueldoMensual = trabajador.SueldoMensual,
                ViveEnLaPropiedad = trabajador.ViveEnLaPropiedad,
                PropiedadAgricolaId = trabajador.PropiedadAgricolaId
            };
        }

        public async Task<int> Crear(TrabajadorRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))
                throw new AccesoExcepcion("No tenés permisos para crear trabajadores");
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Nombre)) errores.Add("El nombre es obligatorio");
            if (string.IsNullOrWhiteSpace(dto.Apellido)) errores.Add("El apellido es obligatorio");
            if (string.IsNullOrWhiteSpace(dto.DNI)) errores.Add("El DNI es obligatorio");
            else if (dto.DNI.Length != 8) errores.Add("El DNI debe tener 8 caracteres");
            if (string.IsNullOrWhiteSpace(dto.Email)) errores.Add("El email es obligatorio");
            else if (!dto.Email.Contains("@")) errores.Add("El email no es válido");
            if (string.IsNullOrWhiteSpace(dto.Cargo)) errores.Add("El cargo es obligatorio");
            if (string.IsNullOrWhiteSpace(dto.TipoContrato)) errores.Add("El tipo de contrato es obligatorio");
            if (dto.SueldoMensual < 0) errores.Add("El sueldo mensual no puede ser negativo");
            if (dto.FechaNacimiento >= DateTime.UtcNow) errores.Add("La fecha de nacimiento no puede ser futura");
            if (dto.FechaIngreso > DateTime.UtcNow) errores.Add("La fecha de ingreso no puede ser futura");
            if (errores.Any()) throw new ValidacionExcepcion(errores);
            var trabajador = new Trabajador();
            trabajador.SetNombre(dto.Nombre);
            trabajador.SetApellido(dto.Apellido);
            trabajador.SetEmail(dto.Email);
            trabajador.DNI = dto.DNI;
            trabajador.Cargo = dto.Cargo;
            trabajador.TipoContrato = dto.TipoContrato;
            trabajador.FechaNacimiento = dto.FechaNacimiento;
            trabajador.FechaIngreso = dto.FechaIngreso;
            trabajador.SueldoMensual = dto.SueldoMensual;
            trabajador.ViveEnLaPropiedad = dto.ViveEnLaPropiedad;
            trabajador.PropiedadAgricolaId = dto.PropiedadAgricolaId;
            _repo.Save(trabajador);
            return trabajador.Id;
        }
        public async Task<bool> Editar(int id, TrabajadorRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para editar trabajadores");
            var trabajador = _repo.GetById(id);
            if (trabajador is null)throw new NoEncontradoExcepcion("Trabajador no encontrado");
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Nombre)) errores.Add("El nombre es obligatorio");
            if (string.IsNullOrWhiteSpace(dto.Apellido)) errores.Add("El apellido es obligatorio");
            if (string.IsNullOrWhiteSpace(dto.DNI)) errores.Add("El DNI es obligatorio");
            else if (dto.DNI.Length != 8) errores.Add("El DNI debe tener 8 caracteres");
            if (!dto.Email.Contains("@")) errores.Add("El email no es válido");
            if (dto.SueldoMensual < 0) errores.Add("El sueldo mensual no puede ser negativo");
            if (dto.FechaNacimiento >= DateTime.UtcNow)errores.Add("La fecha de nacimiento no puede ser futura");
            if (dto.FechaIngreso > DateTime.UtcNow)errores.Add("La fecha de ingreso no puede ser futura");
            if (errores.Any())throw new ValidacionExcepcion(errores);
            trabajador.SetNombre(dto.Nombre);
            trabajador.SetApellido(dto.Apellido);
            trabajador.SetEmail(dto.Email);
            trabajador.DNI = dto.DNI;
            trabajador.Cargo = dto.Cargo;
            trabajador.TipoContrato = dto.TipoContrato;
            trabajador.FechaNacimiento = dto.FechaNacimiento;
            trabajador.FechaIngreso = dto.FechaIngreso;
            trabajador.SueldoMensual = dto.SueldoMensual;
            trabajador.ViveEnLaPropiedad = dto.ViveEnLaPropiedad;
            trabajador.PropiedadAgricolaId = dto.PropiedadAgricolaId;
            _repo.Save(trabajador);
            return true;
        }

        public async Task<bool> Borrar(int id, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para eliminar trabajadores");
            var trabajador = _repo.GetById(id);
            if (trabajador is null)throw new NoEncontradoExcepcion("El trabajador no existe");
            _repo.Delete(trabajador.Id);
            return true;
        }
    }

}
