using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;

namespace Persistence.Database.Config
{
    public class ComandaMercaderiaConfiguration
    {
        public ComandaMercaderiaConfiguration(EntityTypeBuilder<ComandaMercaderia> entityBuilder)
        {
            entityBuilder.ToTable("ComandaMercaderia");
            entityBuilder.Property(m => m.ComandaMercaderiaId).ValueGeneratedOnAdd();


        }
    }

}
