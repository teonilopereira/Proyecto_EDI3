using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Cultivo;
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
    public class CultivoService : ICultivoService
    {
        private readonly IApplication<Cultivo> _repo;
        private readonly UserManager<User> _userManager;

        public CultivoService(IApplication<Cultivo> repo, UserManager<User> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }
        public async Task<IList<CultivoResponseDto>> GetAll(User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador") &&
                !await _userManager.IsInRoleAsync(usuario, "Usuario"))
                throw new AccesoExcepcion("No tenés permisos para ver los cultivos.");

            var lista = _repo.GetAll();
            return lista.Select(c => new CultivoResponseDto
            {
                Id = c.Id,
                Especie = c.Especie,
                Variedad = c.Variedad,
                FechaSiembra = c.FechaSiembra,
                FechaEstimadaCosecha = c.FechaEstimadaCosecha,
                EstadoCultivo = c.EstadoCultivo
            }).ToList();
        }
        public async Task<CultivoResponseDto> ObtenerPorId(int id, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador") &&
                !await _userManager.IsInRoleAsync(usuario, "Usuario"))
                throw new AccesoExcepcion("No tenés permisos para ver cultivos.");

            var cultivo = _repo.GetById(id);
            if (cultivo == null)
                return null;

            return new CultivoResponseDto
            {
                Id = cultivo.Id,
                Especie = cultivo.Especie,
                Variedad = cultivo.Variedad,
                FechaSiembra = cultivo.FechaSiembra,
                FechaEstimadaCosecha = cultivo.FechaEstimadaCosecha,
                EstadoCultivo = cultivo.EstadoCultivo
            };
        }
        public async Task<int> Crear(CultivoRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))
                throw new AccesoExcepcion("No tenés permisos para crear un cultivo.");

            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Especie))
                errores.Add("La especie es obligatoria.");
            if (dto.FechaSiembra == default)
                errores.Add("La fecha de siembra es obligatoria.");
            else if (dto.FechaSiembra > DateTime.UtcNow)
                errores.Add("La fecha de siembra no puede ser futura.");
            if (dto.FechaEstimadaCosecha != null && dto.FechaEstimadaCosecha < dto.FechaSiembra)
                errores.Add("La fecha estimada de cosecha no puede ser anterior a la siembra.");
            if (string.IsNullOrWhiteSpace(dto.EstadoCultivo))
                errores.Add("El estado del cultivo es obligatorio.");
            if (errores.Any())
                throw new ValidacionExcepcion(errores);
            var cultivo = new Cultivo
            {
                Especie = dto.Especie,
                Variedad = dto.Variedad,
                FechaSiembra = dto.FechaSiembra,
                FechaEstimadaCosecha = dto.FechaEstimadaCosecha,
                EstadoCultivo = dto.EstadoCultivo
            };
            _repo.Save(cultivo);
            return cultivo.Id;
        }
        public async Task Editar(int id, CultivoRequestDto cultivo, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))
                throw new AccesoExcepcion("No tenés permisos para editar un cultivo");

            var cultivoDb = _repo.GetById(id);
            if (cultivoDb == null)
                throw new NoEncontradoExcepcion("El cultivo no existe");

            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(cultivo.Especie))
                errores.Add("La especie es obligatoria");

            if (cultivo.FechaSiembra == default)
                errores.Add("La fecha de siembra es obligatoria");

            if (cultivo.FechaSiembra > DateTime.UtcNow)
                errores.Add("La fecha de siembra no puede ser futura");

            if (cultivo.FechaEstimadaCosecha != null &&
                cultivo.FechaEstimadaCosecha < cultivo.FechaSiembra)
                errores.Add("La fecha estimada de cosecha no puede ser anterior a la fecha de siembra");

            if (string.IsNullOrWhiteSpace(cultivo.EstadoCultivo))
                errores.Add("El estado del cultivo es obligatorio");
            bool existe = _repo.GetAll()
                .Any(c =>
                    c.Id != id &&
                    c.Especie == cultivo.Especie &&
                    c.Variedad == cultivo.Variedad &&
                    c.FechaSiembra == cultivo.FechaSiembra
                );

            if (existe)
                errores.Add("Ya existe otro cultivo con la misma especie, variedad y fecha de siembra");

            if (errores.Any())
                throw new ValidacionExcepcion(errores);
            cultivoDb.Especie = cultivo.Especie;
            cultivoDb.Variedad = cultivo.Variedad;
            cultivoDb.FechaSiembra = cultivo.FechaSiembra;
            cultivoDb.FechaEstimadaCosecha = cultivo.FechaEstimadaCosecha;
            cultivoDb.EstadoCultivo = cultivo.EstadoCultivo;

            _repo.Save(cultivoDb);
        }
        public async Task Borrar(int id, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))
                throw new AccesoExcepcion("No tenés permisos para eliminar un cultivo");

            var cultivo = _repo.GetById(id);
            if (cultivo == null)
                throw new NoEncontradoExcepcion("El cultivo no existe");

            var errores = new List<string>();

            if (cultivo.CultivosPorParcelas.Any())
                errores.Add("No se puede eliminar el cultivo porque está asociado a una o más parcelas");

            if (errores.Any())
                throw new ValidacionExcepcion(errores);

            _repo.Delete(cultivo.Id);
        }
    }

}
