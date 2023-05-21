using Application.Interfaces;
using Infraestructure.Persistence;
using Persistence.Database.Models;


namespace Infraestructure.Commands
{
    public class FormaEntregaCommand : IFormaEntregaCommand
    {
        private readonly AppDbContext _context;

        public FormaEntregaCommand(AppDbContext context)
        {
            _context = context;
        }
        public void ActualizeFormaEntrega(FormaEntrega formaEntrega)
        {
            var entryOriginal = _context.FormaEntregas.Single(x => x.FormaEntregaId == formaEntrega.FormaEntregaId);
            entryOriginal.Descripcion = formaEntrega.Descripcion;
            _context.Update(entryOriginal);
            _context.SaveChanges();
        }

        public void InsertFormaEntrega(FormaEntrega formaEntrega)
        {
            _context.Add(formaEntrega);
            _context.SaveChanges();
        }

        public void RemoveFormaEntrega(int formaEntregaId)
        {
            var entryOriginal = _context.FormaEntregas.Single(x => x.FormaEntregaId == formaEntregaId);
            _context.Remove(entryOriginal);
            _context.SaveChanges();
        }
    }
}
