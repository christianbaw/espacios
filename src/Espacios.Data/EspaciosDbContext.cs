using Espacios.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Espacios.Data
{
    public class EspaciosDbContext : DbContext
    {
        public EspaciosDbContext(DbContextOptions<EspaciosDbContext> options) : base(options)
        {
        }

        public DbSet<Campus> Campus { get; set; }
        public DbSet<Edificio> Edificio { get; set; }
        public DbSet<Equipamiento> Equipamiento { get; set; }
        public DbSet<Reservacion> Reservacion { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Unidad> Unidad { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}