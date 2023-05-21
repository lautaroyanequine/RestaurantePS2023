using Application.Interfaces;
using Persistence.Database.Models;


namespace Application.Services
{
    public class FormaEntregaService : IFormaEntregaService
    {
        private readonly IFormaEntregaCommand _command;
        private readonly IFormaEntregaQuery _query;


        public FormaEntregaService(IFormaEntregaCommand command, IFormaEntregaQuery query)
        {
            _command = command;
            _query = query;
        }

        public FormaEntrega CreateFormaEntrega(FormaEntrega formaEntrega)
        {
            var formaEnt = new FormaEntrega
            {
                Descripcion = formaEntrega.Descripcion
            };
            _command.InsertFormaEntrega(formaEnt);
            return formaEnt;
        }

        public void Add(FormaEntrega formaEntrega)
        {
            _command.InsertFormaEntrega(formaEntrega);
        }

        public void Delete(int formaEntregaId)
        {
            _command.RemoveFormaEntrega(formaEntregaId);
        }

        public void Update(FormaEntrega formaEntrega)
        {
            _command.ActualizeFormaEntrega(formaEntrega);
        }
        public List<FormaEntrega> GetAll()
        {
            return (_query.GetListFormaEntrega());
        }

        public FormaEntrega GetFormaEntregaById(int tipoMercaderiaId)
        {
            return (_query.GetFormaEntrega(tipoMercaderiaId));
        }
    }
}
