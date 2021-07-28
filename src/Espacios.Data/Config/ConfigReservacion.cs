using Espacios.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Espacios.Data.Config
{
    public class ConfigReservacion : IEntityTypeConfiguration<Reservacion>
    {
        public void Configure(EntityTypeBuilder<Reservacion> builder)
        {
            builder.Property(x => x.Id)
                .UseHiLo("reservacion_hilo")
                .IsRequired();

            builder.HasOne(x => x.Sala);

            builder.Property(x => x.FechaInicio);

            builder.Property(x => x.FechaFin);

            builder.Property(x => x.Adicionales)
                .HasMaxLength(250);

            builder.Property(c => c.Estatus)
                .HasConversion<int>();
        }
    }
}