using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IComandaCommand
    {
        void InsertComanda(Comanda comanda);
        void RemoveComanda(Guid comandaId);
        void ActualizeComanda(Comanda comanda);

    }
}
