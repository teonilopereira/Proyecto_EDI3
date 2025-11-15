using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Ubicacion;
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
    public class UbicacionService : IUbicaciónService
    {
        private readonly IApplication<Ubicacion> _repo;
        private readonly UserManager<User> _userManager;

        public UbicacionService(IApplication<Ubicacion> repo, UserManager<User> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }
        public async Task<IList<UbicacionResponseDto>> GetAll()
        {
            return _repo.GetAll()
                .Select(u => new UbicacionResponseDto
                {
                    Id = u.Id,
                    Direccion = u.Direccion,
                    Localidad = u.Localidad,
                    Provincia = u.Provincia,
                    CodigoPostal = u.CodigoPostal
                })
                .ToList();
        }

        public async Task<UbicacionResponseDto?> GetById(int id)
        {
            var ubicacion = _repo.GetById(id);

            if (ubicacion is null)
                return null;

            return new UbicacionResponseDto
            {
                Id = ubicacion.Id,
                Direccion = ubicacion.Direccion,
                Localidad = ubicacion.Localidad,
                Provincia = ubicacion.Provincia,
                CodigoPostal = ubicacion.CodigoPostal
            };
        }
        public async Task<int> Crear(UbicacionRequestDto dto)
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Direccion))errores.Add("La dirección es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.Localidad))errores.Add("La localidad es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.Provincia))errores.Add("La provincia es obligatoria");
            if (errores.Any())throw new ValidacionExcepcion(errores);
            var ubicacion = new Ubicacion
            {
                Direccion = dto.Direccion,
                Localidad = dto.Localidad,
                Provincia = dto.Provincia,
                CodigoPostal = dto.CodigoPostal
            };

            _repo.Save(ubicacion);

            return ubicacion.Id;
        }
        public async Task<bool> Editar(int id, UbicacionRequestDto dto)
        {
            var ubicacionBack = _repo.GetById(id);
            if (ubicacionBack is null)
                throw new NoEncontradoExcepcion("Ubicación no encontrada");
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Direccion))errores.Add("La dirección es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.Localidad))errores.Add("La localidad es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.Provincia)) errores.Add("La provincia es obligatoria");
            if (errores.Any())throw new ValidacionExcepcion(errores);
            ubicacionBack.Direccion = dto.Direccion;
            ubicacionBack.Localidad = dto.Localidad;
            ubicacionBack.Provincia = dto.Provincia;
            ubicacionBack.CodigoPostal = dto.CodigoPostal;
            _repo.Save(ubicacionBack);
            return true;
        }
        public async Task<bool> Borrar(int id, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para eliminar ubicaciones");
            var ubicacion = _repo.GetById(id);
            if (ubicacion is null) throw new NoEncontradoExcepcion("La ubicación no existe");
            var errores = new List<string>();
            if (ubicacion.PropiedadesAgricolas.Any()) errores.Add("No se puede eliminar la ubicación porque tiene propiedades agrícolas asociadas");
            if (errores.Any()) throw new ValidacionExcepcion(errores);
            _repo.Delete(ubicacion.Id);
            return true;
        }
    }

}
