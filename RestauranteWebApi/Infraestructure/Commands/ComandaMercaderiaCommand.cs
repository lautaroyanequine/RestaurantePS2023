using Application.Interfaces;
using Infraestructure.Persistence;
using Persistence.Database.Models;


namespace Infraestructure.Commands
{
    public class ComandaMercaderiaCommand : IComandaMercaderiaCommand
    {
        private readonly AppDbContext _context;

        public ComandaMercaderiaCommand(AppDbContext context)
        {
            _context = context;
        }
        public void ActualizeComandaMercaderia(ComandaMercaderia comandaMercaderia)
        {
            var entryOriginal = _context.ComandaMercaderias.Single(x => x.ComandaMercaderiaId == comandaMercaderia.ComandaMercaderiaId);
            entryOriginal.MercaderiaId = comandaMercaderia.MercaderiaId;
            entryOriginal.ComandaId = comandaMercaderia.ComandaId;
            _context.Update(entryOriginal);
            _context.SaveChanges();
        }

        public void InsertComandaMercaderia(ComandaMercaderia comandaMercaderia)
        {
            _context.Add(comandaMercaderia);
            _context.SaveChanges();
        }

        public void RemoveComandaMercaderia(int comandaMercaderiaId)
        {
            var entryOriginal = _context.ComandaMercaderias.Single(x => x.ComandaMercaderiaId == comandaMercaderiaId);
            _context.Remove(entryOriginal);
            _context.SaveChanges();
        }
    }
}
