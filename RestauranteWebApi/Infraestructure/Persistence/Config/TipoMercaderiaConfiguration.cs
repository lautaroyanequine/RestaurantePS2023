using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;

namespace Persistence.Database.Config
{
    public class TipoMercaderiaConfiguration
    {
        public TipoMercaderiaConfiguration(EntityTypeBuilder<TipoMercaderia> entityBuilder)
        {
            entityBuilder.ToTable("TipoMercaderia");
            entityBuilder.Property(m => m.TipoMercaderiaId).ValueGeneratedOnAdd();
            entityBuilder.Property(foren => foren.Descripcion).HasMaxLength(50);
            entityBuilder
                .HasMany<Mercaderia>(tm => tm.Mercaderias)
                .WithOne(m => m.TipoMercaderia)
                .HasForeignKey(m => m.TipoMercaderiaId);
        }
    }
}
