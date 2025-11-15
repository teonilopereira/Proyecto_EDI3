using GestionPropiedadesAgricolas.Application;
using GestionPropiedadesAgricolas.Application.Dtos.Parcela;
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
    public class ParcelaService : IParcelaService
    {
        private readonly IApplication<Parcela> _repo;
        private readonly UserManager<User> _userManager;

        public ParcelaService(IApplication<Parcela> repo, UserManager<User> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        public async Task<IList<ParcelaResponseDto>> GetAll(User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador") &&
                !await _userManager.IsInRoleAsync(usuario, "Usuario"))
                throw new AccesoExcepcion("No tenés permisos para ver las parcelas");

            var parcelas = _repo.GetAll();
            return parcelas.Select(p => new ParcelaResponseDto
            {
                Id = p.Id,
                PropiedadAgricolaId = p.PropiedadAgricolaId,
                CodigoParcela = p.CodigoParcela,
                Superficie = p.Superficie,
                Nombre = p.Nombre,
                UsoActual = p.UsoActual
            }).ToList();
        }
        public async Task<ParcelaResponseDto> ObtenerPorId(int id)
        {
            var parcela = _repo.GetById(id);
            if (parcela == null)
                throw new NoEncontradoExcepcion("La parcela no existe");

            return new ParcelaResponseDto
            {
                Id = parcela.Id,
                PropiedadAgricolaId = parcela.PropiedadAgricolaId,
                CodigoParcela = parcela.CodigoParcela,
                Superficie = parcela.Superficie,
                Nombre = parcela.Nombre,
                UsoActual = parcela.UsoActual
            };
        }
        public async Task<int> Crear(ParcelaRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))
                throw new AccesoExcepcion("No tenés permisos para crear una parcela.");
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.CodigoParcela))
                errores.Add("El código de parcela es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                errores.Add("El nombre de la parcela es obligatorio.");
            if (dto.Superficie <= 0)
                errores.Add("La superficie debe ser mayor a 0.");
            if (string.IsNullOrWhiteSpace(dto.UsoActual))
                errores.Add("El uso actual es obligatorio.");
            if (errores.Any())
                throw new ValidacionExcepcion(errores);
            if (_repo.GetAll().Any(p => p.CodigoParcela == dto.CodigoParcela))
                throw new ValidacionExcepcion(new[] { "Ya existe una parcela con ese código." });
            var parcela = new Parcela
            {
                CodigoParcela = dto.CodigoParcela,
                Superficie = dto.Superficie,
                UsoActual = dto.UsoActual
            };
            parcela.SetNombre(dto.Nombre);

            _repo.Save(parcela);
            return parcela.Id;
        }
       public async Task Editar(int id, ParcelaRequestDto dto, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))
                throw new AccesoExcepcion("No tenés permisos para editar una parcela.");

            var parcelaDb = _repo.GetById(id);
            if (parcelaDb == null)
                throw new NoEncontradoExcepcion("La parcela no existe.");

            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.CodigoParcela))
                errores.Add("El código de parcela es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                errores.Add("El nombre de la parcela es obligatorio.");
            if (dto.Superficie <= 0)
                errores.Add("La superficie debe ser mayor a 0.");
            if (string.IsNullOrWhiteSpace(dto.UsoActual))
                errores.Add("El uso actual es obligatorio.");

            if (errores.Any())
                throw new ValidacionExcepcion(errores);

            if (_repo.GetAll().Any(p => p.Id != id && p.CodigoParcela == dto.CodigoParcela))
                throw new ValidacionExcepcion(new[] { "Otra parcela ya usa ese código." });

            parcelaDb.CodigoParcela = dto.CodigoParcela;
            parcelaDb.Superficie = dto.Superficie;
            parcelaDb.UsoActual = dto.UsoActual;
            parcelaDb.SetNombre(dto.Nombre);

            _repo.Save(parcelaDb);
        }
        public async Task Borrar(int id, User usuario)
        {
            if (!await _userManager.IsInRoleAsync(usuario, "Administrador"))
                throw new AccesoExcepcion("No tenés permisos para eliminar una parcela");
            var parcela = _repo.GetById(id);
            if (parcela == null)
                throw new NoEncontradoExcepcion("La parcela no existe");
            var errores = new List<string>();
            if (parcela.CultivosPorParcelas.Any())
                errores.Add("No se puede eliminar la parcela porque tiene cultivos asociados");
            if (errores.Any()) throw new ValidacionExcepcion(errores);
            _repo.Delete(parcela.Id);
        }
    }

}
