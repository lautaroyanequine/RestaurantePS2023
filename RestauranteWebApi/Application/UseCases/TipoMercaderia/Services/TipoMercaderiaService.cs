using Application.Interfaces;
using Persistence.Database.Models;


namespace Application.Services
{
    public class TipoMercaderiaService : ITipoMercaderiaService
    {
        private readonly ITipoMercaderiaCommand _command;
        private readonly ITipoMercaderiaQuery _query;

        public TipoMercaderiaService(ITipoMercaderiaCommand command, ITipoMercaderiaQuery query)
        {
            _command = command;
            _query = query;
        }

        public TipoMercaderia CreateTipoMercaderia(TipoMercaderia tipoMercaderia)
        {

            var tipoMer = new TipoMercaderia
            {
                Descripcion = tipoMercaderia.Descripcion
            };
            _command.InsertTipoMercaderia(tipoMer);
            return tipoMer;
        }

        public void Add(TipoMercaderia tipoMercaderia)
        {
            _command.InsertTipoMercaderia(tipoMercaderia);
        }

        public void Delete(int tipoMercaderiaId)
        {
            _command.RemoveTipoMercaderia(tipoMercaderiaId);
        }

        public void Update(TipoMercaderia tipoMercaderia)
        {
            _command.ActualizeTipoMercaderia(tipoMercaderia);
        }
        public List<TipoMercaderia> GetAll()
        {
            return (_query.GetListTipoMercaderia());
        }

        public TipoMercaderia GetTipoMercaderiaById(int tipoMercaderiaId)
        {
            return (_query.GetTipoMercaderia(tipoMercaderiaId));
        }

    }
}
