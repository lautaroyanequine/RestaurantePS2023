using Application.Request;
using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IMercaderiaCommand
    {
        void InsertMercaderia(Mercaderia mercaderia);
        Mercaderia RemoveMercaderia(int mercaderiaId);
        Mercaderia ActualizeMercaderia(int mercaderiaId, MercaderiaRequest mercaderia);

    }
}
