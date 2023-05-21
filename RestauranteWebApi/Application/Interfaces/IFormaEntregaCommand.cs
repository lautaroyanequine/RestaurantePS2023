using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IFormaEntregaCommand
    {
        void InsertFormaEntrega(FormaEntrega formaEntrega);
        void RemoveFormaEntrega(int formaEntregaId);
        void ActualizeFormaEntrega(FormaEntrega formaEntrega);
    }
}
