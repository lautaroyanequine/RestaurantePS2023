using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface ITipoMercaderiaService
    {
        TipoMercaderia CreateTipoMercaderia(TipoMercaderia tipoMercaderia);

        public void Add(TipoMercaderia tipoMercaderia);
        public void Update(TipoMercaderia tipoMercaderia);
        public void Delete(int tipoMercaderiaId);
        public TipoMercaderia GetTipoMercaderiaById(int tipoMercaderiaId);
        public List<TipoMercaderia> GetAll();
        //public TipoMercaderiaResponse ExitsMercaderia(string nombre);

    }
}
