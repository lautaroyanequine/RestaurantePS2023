using Application.Request.Comanda;
using Application.Response.Comanda;
using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IComandaService
    {
        public void Update(Comanda comanda);
        public void Delete(Guid comandaId);
        public ComandaGetResponse GetComandaById(Guid comandaId);
        public List<Comanda> GetAll();
        public List<ComandaResponse> GetAllOrderedForDate(string? fecha = null);

        public ComandaResponse CreateComanda(ComandaRequest request);



    }
}
