using Espacios.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Espacios.Data.Config
{
    public class ConfigCampus : IEntityTypeConfiguration<Campus>
    {
        public void Configure(EntityTypeBuilder<Campus> builder)
        {
            builder.Property(x => x.Id)
                .UseHiLo("campus_hilo")
                .IsRequired();

            builder.Property(ci => ci.Nombre)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasOne(x => x.Unidad);

            builder.HasMany(x => x.Edificios)
                .WithOne(x => x.Campus)
                .HasForeignKey(x => x.CampusId);
        }
    }
}