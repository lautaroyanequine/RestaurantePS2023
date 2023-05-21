using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IComandaMercaderiaQuery
    {
        List<ComandaMercaderia> GetListComandaMercaderia();
        ComandaMercaderia GetComandaMercaderia(int comandaMercaderiaId);
    }
}
