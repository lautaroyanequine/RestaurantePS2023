using Application.Interfaces;
using Infraestructure.Persistence;
using Persistence.Database.Models;


namespace Infraestructure.Querys
{
    public class TipoMercaderiaQuery : ITipoMercaderiaQuery
    {
        private readonly AppDbContext _context;

        public TipoMercaderiaQuery(AppDbContext context)
        {
            _context = context;
        }


        public List<TipoMercaderia> GetListTipoMercaderia()
        {
            return (_context.TipoMercaderias.OrderBy(x => x.TipoMercaderiaId).ToList());
        }

        public TipoMercaderia GetTipoMercaderia(int id)
        {
            return (_context.TipoMercaderias.FirstOrDefault(x => x.TipoMercaderiaId == id)
                 );
        }
    }
}
