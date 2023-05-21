using Persistence.Database.Models;

namespace Application.Interfaces
{
    public interface IMercaderiaQuery
    {
        List<Mercaderia> GetListMercaderia();
        List<Mercaderia> GetListFilteredMercaderia(string? orden = "ASC", string? nombre = null, int? tipo = null);

        Mercaderia GetMercaderia(int MercaderiaId);

        Mercaderia GetMercaderia(string nombre);
    }
}
