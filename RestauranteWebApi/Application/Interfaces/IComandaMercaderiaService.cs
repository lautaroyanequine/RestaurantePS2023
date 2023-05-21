using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IComandaMercaderiaService
    {
        ComandaMercaderia CreateComandaMercaderia(ComandaMercaderia comandaMercaderia);
        public void Add(ComandaMercaderia comandaMercaderia);
        public void Update(ComandaMercaderia comandaMercaderia);
        public void Delete(int comandaMercaderiaId);
        public ComandaMercaderia GetComandaById(int comandaMercaderiaId);
        public List<ComandaMercaderia> GetAll();
    }
}
