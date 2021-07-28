using Espacios.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Espacios.Data.Config
{
    public class SalaConfig : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.Property(x => x.Id)
                .UseHiLo("sala_hilo")
                .IsRequired();

            builder.Property(x => x.Nombre)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.Capacidad);

            builder.HasOne(x => x.Edificio);

            builder.HasMany(x => x.Reservaciones)
                .WithOne(x => x.Sala)
                .HasForeignKey(x => x.SalaId);

            builder.HasMany(x => x.Equipamientos)
                .WithOne(x => x.Sala)
                .HasForeignKey(x => x.SalaId);
        }
    }
}