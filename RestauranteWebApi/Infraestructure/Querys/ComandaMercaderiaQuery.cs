using Application.Interfaces;
using Infraestructure.Persistence;
using Persistence.Database.Models;

namespace Infraestructure.Querys
{
    public class ComandaMercaderiaQuery : IComandaMercaderiaQuery
    {
        private readonly AppDbContext _context;

        public ComandaMercaderiaQuery(AppDbContext context)
        {
            _context = context;
        }
        public ComandaMercaderia GetComandaMercaderia(int comandaMercaderiaId)
        {
            return (_context.ComandaMercaderias.Single(x => x.ComandaMercaderiaId == comandaMercaderiaId)
                             );
        }

        public List<ComandaMercaderia> GetListComandaMercaderia()
        {
            return _context.ComandaMercaderias.OrderBy(x => x.ComandaMercaderiaId).ToList();
        }
    }
}
