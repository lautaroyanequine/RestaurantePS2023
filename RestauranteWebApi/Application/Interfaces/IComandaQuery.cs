using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IComandaQuery
    {
        List<Comanda> GetListComanda();
        Comanda GetComanda(Guid comandaId);
        public List<Comanda> GetListComandaOrderedForDate(string? fecha);

    }
}
