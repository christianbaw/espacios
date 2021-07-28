using Espacios.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Espacios.Data.Config
{
    public class ConfigEquipamiento : IEntityTypeConfiguration<Equipamiento>
    {
        public void Configure(EntityTypeBuilder<Equipamiento> builder)
        {
            builder.Property(x => x.Id)
                .UseHiLo("equipamiento_hilo")
                .IsRequired();

            builder.Property(x => x.Nombre)
                .IsRequired(true)
                .HasMaxLength(50);
        }
    }
}