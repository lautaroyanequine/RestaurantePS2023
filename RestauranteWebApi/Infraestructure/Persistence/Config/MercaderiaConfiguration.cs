using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;


namespace Persistence.Database.Config
{
    public class MercaderiaConfiguration
    {
        public MercaderiaConfiguration(EntityTypeBuilder<Mercaderia> entityBuilder)
        {
            entityBuilder.ToTable("Mercaderia");
            entityBuilder.Property(m => m.MercaderiaId).ValueGeneratedOnAdd();
            entityBuilder.Property(foren => foren.Nombre).HasMaxLength(50);
            entityBuilder.Property(foren => foren.Ingredientes).HasMaxLength(255);
            entityBuilder.Property(foren => foren.Preparacion).HasMaxLength(255);
            entityBuilder.Property(foren => foren.Imagen).HasMaxLength(255);

            entityBuilder
                .HasMany<ComandaMercaderia>(m => m.ComandasMercaderia)
                .WithOne(cm => cm.Mercaderia)
                .HasForeignKey(cm => cm.MercaderiaId);
        }
    }
}
