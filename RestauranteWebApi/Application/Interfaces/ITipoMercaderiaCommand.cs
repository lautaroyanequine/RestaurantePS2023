using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface ITipoMercaderiaCommand
    {
        void InsertTipoMercaderia(TipoMercaderia tipoMercaderia);
        void RemoveTipoMercaderia(int tipoMercaderiaId);
        void ActualizeTipoMercaderia(TipoMercaderia tipoMercaderia);

    }
}
