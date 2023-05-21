using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface ITipoMercaderiaQuery
    {

        List<TipoMercaderia> GetListTipoMercaderia();
        TipoMercaderia GetTipoMercaderia(int id);

    }
}
