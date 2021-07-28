using Espacios.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Espacios.Data.Config
{
    public class ConfigSalaEquipamiento : IEntityTypeConfiguration<SalaEquipamiento>
    {
        public void Configure(EntityTypeBuilder<SalaEquipamiento> builder)
        {
            builder.HasKey(c => new { c.SalaId, c.EquipamientoId });
            builder.HasOne(c => c.Sala);
            builder.HasOne(c => c.Equipamiento);
        }
    }
}