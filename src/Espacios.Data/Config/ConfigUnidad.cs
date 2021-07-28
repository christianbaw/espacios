using Espacios.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Espacios.Data.Config
{
    public class ConfigUnidad : IEntityTypeConfiguration<Unidad>
    {
        public void Configure(EntityTypeBuilder<Unidad> builder)
        {
            builder.Property(x => x.Id)
                .UseHiLo("unidad_hilo")
                .IsRequired();

            builder.Property(ci => ci.Nombre)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasMany(x => x.Campus)
                .WithOne(x => x.Unidad)
                .HasForeignKey(x => x.UnidadId);
        }
    }
}