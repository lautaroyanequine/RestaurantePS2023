using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;


namespace Infraestructure.Persistence.DataRestaurante
{
    public class FormaEntregaData
    {
        public FormaEntregaData(EntityTypeBuilder<FormaEntrega> entityBuilder)
        {
            entityBuilder.HasData(
                new FormaEntrega { FormaEntregaId = 1, Descripcion = "Salon" },
                new FormaEntrega { FormaEntregaId = 2, Descripcion = "Delivery" },
                new FormaEntrega { FormaEntregaId = 3, Descripcion = "Pedidos Ya" }
                );
        }
    }
}
