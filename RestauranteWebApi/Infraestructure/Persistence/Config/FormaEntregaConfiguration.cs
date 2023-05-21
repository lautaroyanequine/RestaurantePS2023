using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;

namespace Persistence.Database.Config
{
    public class FormaEntregaConfiguration
    {
        public FormaEntregaConfiguration(EntityTypeBuilder<FormaEntrega> entityBuilder)
        {
            entityBuilder.ToTable("FormaEntrega");
            entityBuilder.Property(m => m.FormaEntregaId).ValueGeneratedOnAdd();
            entityBuilder.Property(foren => foren.Descripcion).HasMaxLength(50);
            entityBuilder
                .HasMany<Comanda>(fm => fm.Comandas)
                .WithOne(c => c.FormaEntrega)
                .HasForeignKey(c => c.FormaEntregaId);


        }
    }
}
