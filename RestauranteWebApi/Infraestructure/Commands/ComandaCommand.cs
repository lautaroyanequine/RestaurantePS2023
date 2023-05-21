using Application.Interfaces;
using Infraestructure.Persistence;
using Persistence.Database.Models;


namespace Infraestructure.Commands
{
    public class ComandaCommand : IComandaCommand
    {
        private readonly AppDbContext _context;
        public ComandaCommand(AppDbContext context)
        {
            _context = context;
        }
        public void ActualizeComanda(Comanda comanda)
        {
            var entryOriginal = _context.Comandas.Single(x => x.ComandaId == comanda.ComandaId);
            entryOriginal.FormaEntregaId = comanda.FormaEntregaId;
            entryOriginal.PrecioTotal = comanda.PrecioTotal;
            entryOriginal.Fecha = comanda.Fecha;
            _context.Update(entryOriginal);
            _context.SaveChanges();
        }

        public void InsertComanda(Comanda comanda)
        {
            _context.Add(comanda);
            _context.SaveChanges();
        }

        public void RemoveComanda(Guid comandaId)
        {
            var entryOriginal = _context.Comandas.Single(x => x.ComandaId == comandaId);
            _context.Remove(entryOriginal);
            _context.SaveChanges();
        }


    }
}
