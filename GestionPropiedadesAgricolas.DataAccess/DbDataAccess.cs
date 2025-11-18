using GestionPropiedadesAgricolas.Entities;
using GestionPropiedadesAgricolas.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.DataAccess
{
    public class DbDataAccess : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken> 
    {
        public virtual DbSet<Cultivo> Cultivos { get; set; }
        public virtual DbSet<Parcela> Parcelas { get; set; }
        public virtual DbSet<PropiedadAgricola> PropiedadAgricolas { get; set; }
        public virtual DbSet<Propietario> Propietarios { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Trabajador> Trabajadores { get; set; }
        public virtual DbSet<Ubicacion> Ubicacions { get; set; }
        public virtual DbSet<CultivoPorParcela> CultivosPorParcelas { get; set; }
        public virtual DbSet<ProveedorPorPropiedadAgricola> ProveedoresPorPropiedadAgricolas { get; set; }
        public virtual DbSet<PropiedadAgricola> PropiedadesAgricolas { get; set; }
        public DbDataAccess(DbContextOptions<DbDataAccess> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine).EnableDetailedErrors();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
