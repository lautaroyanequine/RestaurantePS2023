using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IFormaEntregaService
    {
        FormaEntrega CreateFormaEntrega(FormaEntrega formaEntrega);
        public void Add(FormaEntrega formaEntrega);
        public void Update(FormaEntrega formaEntrega);
        public void Delete(int formaEntregaId);
        public FormaEntrega GetFormaEntregaById(int formaEntregaId);
        public List<FormaEntrega> GetAll();
    }
}
