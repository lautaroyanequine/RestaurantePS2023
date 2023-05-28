using Application.Interfaces;
using Infraestructure.Persistence;
using Persistence.Database.Models;


namespace Infraestructure.Querys
{
    public class MercaderiaQuery : IMercaderiaQuery
    {
        private readonly AppDbContext _context;

        public MercaderiaQuery(AppDbContext context)
        {
            _context = context;
        }

      

        public Mercaderia GetMercaderia(int MercaderiaId)
        {
            return (_context.Mercaderias.FirstOrDefault(x => x.MercaderiaId == MercaderiaId)
                            );
        }

        public Mercaderia GetMercaderia(string nombre)
        {
            return (_context.Mercaderias.FirstOrDefault(x => x.Nombre == nombre)
                );

        }
        public List<Mercaderia> GetListMercaderia(string? orden = null, string? nombre = null, int? tipo = null)
        {
            IQueryable<Mercaderia> query = _context.Mercaderias;

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }
            if (tipo > 0 && tipo != null )
            {
                query = query.Where(p => p.TipoMercaderia.TipoMercaderiaId == tipo);
            }
            if(orden != null)
            {
                if (orden.ToUpper() == "ASC") query = query.OrderBy(p => p.Precio);
                else if (orden.ToUpper() == "DESC") query = query.OrderByDescending(p => p.Precio);
            }
          

            return query.ToList();
        }


    }
}
