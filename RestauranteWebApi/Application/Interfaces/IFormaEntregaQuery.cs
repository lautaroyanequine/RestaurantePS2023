using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IFormaEntregaQuery
    {
        List<FormaEntrega> GetListFormaEntrega();
        FormaEntrega GetFormaEntrega(int id);
    }
}
