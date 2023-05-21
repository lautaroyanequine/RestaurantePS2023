using Application.Interfaces;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Database.Models;


namespace Infraestructure.Querys
{
    public class ComandaQuery : IComandaQuery
    {
        private readonly AppDbContext _context;

        public ComandaQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<Comanda> GetListComanda()
        {
            return _context.Comandas.OrderBy(x => x.ComandaId).ToList();
        }
        public List<Comanda> GetListComandaOrderedForDate(string? fecha)
        {
            IQueryable<Comanda> query = _context.Comandas.Include(tm => tm.ComandasMercaderia);

            if (fecha != null)
            {
                query = query

                    .OrderBy(x => x.Fecha)
                    .Where(x => x.Fecha.ToString().Contains(fecha));

            }


            return query.ToList();
        }

        public Comanda GetComanda(Guid comandaId)
        {
            var Comanda = _context.Comandas
                .Include(cm => cm.ComandasMercaderia)
                .FirstOrDefault(C => C.ComandaId == comandaId);
            return Comanda;
        }
    }
}

