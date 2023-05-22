using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IComandaQuery
    {
        Comanda GetComanda(Guid comandaId);
        public List<Comanda> GetList(string? fecha);

    }
}
