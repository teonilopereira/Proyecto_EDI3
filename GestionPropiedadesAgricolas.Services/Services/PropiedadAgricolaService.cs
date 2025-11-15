using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.PropiedadAgricola;
using GestionPropiedadesAgricolas.Entities;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using GestionPropiedadesAgricolas.Exceptions;
using GestionPropiedadesAgricolas.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace GestionPropiedadesAgricolas.Services.Services
{
    public class PropiedadAgricolaService : IPropiedadAgricolaService
    {
        private readonly IApplication<PropiedadAgricola> _repo;
        private readonly UserManager<User> _userManager;

        public PropiedadAgricolaService(IApplication<PropiedadAgricola> repo, UserManager<User> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        public async Task<IList<PropiedadAgricolaResponseDto>> GetAll(User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))
                throw new AccesoExcepcion("No tenés permisos para ver las propiedades agrícolas");

            var lista = _repo.GetAll();
            return lista.Select(p => new PropiedadAgricolaResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Superficie = p.Superficie,
                TipoSuelo = p.TipoSuelo,
                FechaAdquisicion = p.FechaAdquisicion,
                Estado = p.Estado,
                PropietarioId = p.PropietarioId,
                UbicacionId = p.UbicacionId
            }).ToList();
        }

        public async Task<PropiedadAgricolaResponseDto> GetById(int id)
        {
            var propiedad = _repo.GetById(id);
            if (propiedad == null)throw new NoEncontradoExcepcion("Propiedad agrícola no encontrada");

            return new PropiedadAgricolaResponseDto
            {
                Id = propiedad.Id,
                Nombre = propiedad.Nombre,
                Superficie = propiedad.Superficie,
                TipoSuelo = propiedad.TipoSuelo,
                FechaAdquisicion = propiedad.FechaAdquisicion,
                Estado = propiedad.Estado,
                PropietarioId = propiedad.PropietarioId,
                UbicacionId = propiedad.UbicacionId
            };
        }

        public async Task<int> Crear(PropiedadAgricolaRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para crear una propiedad agrícola");

            ValidarPropiedadAgricola(dto);

            var entidad = new PropiedadAgricola
            {
                Superficie = dto.Superficie,
                TipoSuelo = dto.TipoSuelo,
                FechaAdquisicion = dto.FechaAdquisicion,
                Estado = dto.Estado,
                PropietarioId = dto.PropietarioId,
                UbicacionId = dto.UbicacionId
            };
            entidad.SetNombre(dto.Nombre);

            _repo.Save(entidad);
            return entidad.Id;
        }

        public async Task Editar(int id, PropiedadAgricolaRequestDto dto)
        {
            var propiedad = _repo.GetById(id);
            if (propiedad == null)
                throw new NoEncontradoExcepcion("Propiedad agrícola no encontrada");
            ValidarPropiedadAgricola(dto);
            bool existe = _repo.GetAll()
                .Any(p => p.Id != id && p.Nombre == dto.Nombre && p.PropietarioId == dto.PropietarioId);
            if (existe)throw new ValidacionExcepcion(new[] { "Ya existe una propiedad con ese nombre para el mismo propietario" });

            propiedad.SetNombre(dto.Nombre);
            propiedad.Superficie = dto.Superficie;
            propiedad.TipoSuelo = dto.TipoSuelo;
            propiedad.FechaAdquisicion = dto.FechaAdquisicion;
            propiedad.Estado = dto.Estado;
            propiedad.PropietarioId = dto.PropietarioId;
            propiedad.UbicacionId = dto.UbicacionId;

            _repo.Save(propiedad);
        }
        public async Task Borrar(int id, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))throw new AccesoExcepcion("No tenés permisos para eliminar una propiedad agrícola");
            var propiedad = _repo.GetById(id);
            if (propiedad == null)
                throw new ValidacionExcepcion(new[] { "La propiedad agrícola no existe" });
            var errores = new List<string>();
            if (propiedad.Parcelas.Any())
                errores.Add("No se puede eliminar la propiedad porque tiene parcelas asociadas");
            if (propiedad.ProveedoresPorPropiedadesAgricolas.Any())
                errores.Add("No se puede eliminar la propiedad porque tiene proveedores asociados");
            if (errores.Any())
                throw new ValidacionExcepcion(errores);
            _repo.Delete(propiedad.Id);
        }

        private void ValidarPropiedadAgricola(PropiedadAgricolaRequestDto dto)
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Nombre)) errores.Add("El nombre es obligatorio");
            if (dto.Superficie <= 0) errores.Add("La superficie debe ser mayor a 0");
            if (string.IsNullOrWhiteSpace(dto.TipoSuelo)) errores.Add("El tipo de suelo es obligatorio");
            if (dto.FechaAdquisicion == null) errores.Add("La fecha de adquisición es obligatoria");
            else if (dto.FechaAdquisicion > DateTime.UtcNow) errores.Add("La fecha de adquisición no puede ser futura");
            if (string.IsNullOrWhiteSpace(dto.Estado)) errores.Add("El estado de la propiedad agrícola es obligatorio");
            if (errores.Any())
                throw new ValidacionExcepcion(errores);
        }
    }

}
