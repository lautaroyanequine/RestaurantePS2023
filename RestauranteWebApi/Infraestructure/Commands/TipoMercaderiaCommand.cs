using Application.Interfaces;
using Infraestructure.Persistence;
using Persistence.Database.Models;


namespace Infraestructure.Commands
{
    public class TipoMercaderiaCommand : ITipoMercaderiaCommand
    {
        private readonly AppDbContext _context;

        public TipoMercaderiaCommand(AppDbContext context)
        {
            _context = context;
        }

        public void InsertTipoMercaderia(TipoMercaderia tipoMercaderia)
        {
            _context.Add(tipoMercaderia);

            _context.SaveChanges();
        }

        public void RemoveTipoMercaderia(int tipoMercaderiaId)
        {
            var entryOriginal = _context.TipoMercaderias.Single(x => x.TipoMercaderiaId == tipoMercaderiaId);
            _context.Remove(entryOriginal);
            _context.SaveChanges();
        }

        public void ActualizeTipoMercaderia(TipoMercaderia tipoMercaderia)
        {
            var entryOriginal = _context.TipoMercaderias.Single(x => x.TipoMercaderiaId == tipoMercaderia.TipoMercaderiaId);
            entryOriginal.Descripcion = tipoMercaderia.Descripcion;

            _context.Update(entryOriginal);
            _context.SaveChanges();
        }
    }
}
