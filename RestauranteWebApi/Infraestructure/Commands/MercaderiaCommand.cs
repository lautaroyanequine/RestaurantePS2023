using Application.Interfaces;
using Application.Request;
using Infraestructure.Persistence;
using Persistence.Database.Models;


namespace Infraestructure.Commands
{
    public class MercaderiaCommand : IMercaderiaCommand
    {

        private readonly AppDbContext _context;

        public MercaderiaCommand(AppDbContext context)
        {
            _context = context;
        }

        public Mercaderia ActualizeMercaderia(int mercaderiaId, MercaderiaRequest mercaderia)
        {
            var updateMercaderia = _context.Mercaderias
                .FirstOrDefault(x => x.MercaderiaId == mercaderiaId);
            if (updateMercaderia != null)
            {
                updateMercaderia.Nombre = mercaderia.Nombre;
                updateMercaderia.Precio = mercaderia.Precio;
                updateMercaderia.Ingredientes = mercaderia.Ingredientes;
                updateMercaderia.Preparacion = mercaderia.Preparacion;
                updateMercaderia.Imagen = mercaderia.Imagen;
                updateMercaderia.TipoMercaderiaId = mercaderia.Tipo;
                _context.Update(updateMercaderia);
                _context.SaveChanges();
            }
            return updateMercaderia;
        }

        public void InsertMercaderia(Mercaderia mercaderia)
        {
            _context.Add(mercaderia);

            _context.SaveChanges();
        }

        public Mercaderia RemoveMercaderia(int mercaderiaId)
        {
            var entryOriginal = _context.Mercaderias.FirstOrDefault(x => x.MercaderiaId == mercaderiaId);
            if (entryOriginal != null)
            {
                _context.Remove(entryOriginal);
                _context.SaveChanges();
                return entryOriginal;
            }
            return null;
        }


    }
}
