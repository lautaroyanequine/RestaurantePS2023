using Application.Interfaces;
using Infraestructure.Persistence;
using Persistence.Database.Models;


namespace Infraestructure.Querys
{
    public class FormaEntregaQuery : IFormaEntregaQuery
    {
        private readonly AppDbContext _context;

        public FormaEntregaQuery(AppDbContext context)
        {
            _context = context;
        }
        public FormaEntrega GetFormaEntrega(int id)
        {
            return (_context.FormaEntregas.FirstOrDefault(x => x.FormaEntregaId == id)
                 );
        }

        public List<FormaEntrega> GetListFormaEntrega()
        {
            return _context.FormaEntregas.OrderBy(x => x.FormaEntregaId).ToList();
        }
    }
}
