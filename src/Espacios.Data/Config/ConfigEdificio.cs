using Espacios.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Espacios.Data.Config
{
    public class EdificioConfig : IEntityTypeConfiguration<Edificio>
    {
        public void Configure(EntityTypeBuilder<Edificio> builder)
        {
            builder.Property(x => x.Id)
                .UseHiLo("edificio_hilo")
                .IsRequired();

            builder.Property(x => x.Nombre)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasOne(x => x.Campus);

            builder.HasMany(x => x.Salas)
                .WithOne(x => x.Edificio)
                .HasForeignKey(x => x.EdificioId);
        }
    }
}