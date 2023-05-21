using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;

namespace Persistence.Database.Config
{
    public class ComandaConfiguration
    {
        public ComandaConfiguration(EntityTypeBuilder<Comanda> entityBuilder)
        {
            entityBuilder.ToTable("Comanda");
            entityBuilder.Property(m => m.ComandaId).ValueGeneratedOnAdd();
            entityBuilder
                .HasMany<ComandaMercaderia>(c => c.ComandasMercaderia)
                .WithOne(cm => cm.Comanda)
                .HasForeignKey(cm => cm.ComandaId);
        }
    }
}
