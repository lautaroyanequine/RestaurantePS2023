using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IComandaMercaderiaCommand
    {
        void InsertComandaMercaderia(ComandaMercaderia comandaMercaderia);
        void RemoveComandaMercaderia(int comandaMercaderiaId);
        void ActualizeComandaMercaderia(ComandaMercaderia comandaMercaderia);
    }
}
