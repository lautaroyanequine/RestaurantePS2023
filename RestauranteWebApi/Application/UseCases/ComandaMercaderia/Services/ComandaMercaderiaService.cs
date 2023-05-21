using Application.Interfaces;
using Persistence.Database.Models;


namespace Application.Services
{
    public class ComandaMercaderiaService : IComandaMercaderiaService
    {

        private readonly IComandaMercaderiaCommand _command;
        private readonly IComandaMercaderiaQuery _query;


        public ComandaMercaderiaService(IComandaMercaderiaCommand command, IComandaMercaderiaQuery query)
        {
            _command = command;
            _query = query;
        }
        public void Add(ComandaMercaderia comandaMercaderia)
        {
            _command.InsertComandaMercaderia(comandaMercaderia);
        }

        public ComandaMercaderia CreateComandaMercaderia(ComandaMercaderia comandaMercaderia)
        {
            var comandaMer = new ComandaMercaderia
            {
                ComandaId = comandaMercaderia.ComandaId,
                MercaderiaId = comandaMercaderia.MercaderiaId
            };
            _command.InsertComandaMercaderia(comandaMer);
            return comandaMer;
        }

        public void Delete(int comandaMercaderiaId)
        {
            _command.RemoveComandaMercaderia(comandaMercaderiaId);
        }

        public List<ComandaMercaderia> GetAll()
        {
            return (_query.GetListComandaMercaderia());
        }

        public ComandaMercaderia GetComandaById(int comandaMercaderiaId)
        {
            return (_query.GetComandaMercaderia(comandaMercaderiaId));
        }

        public void Update(ComandaMercaderia comandaMercaderia)
        {
            _command.ActualizeComandaMercaderia(comandaMercaderia);
        }
    }
}
