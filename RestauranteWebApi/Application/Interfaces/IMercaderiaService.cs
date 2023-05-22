using Application.Request;
using Application.Response;
using Application.Response.Mercaderia;
using Persistence.Database.Models;


namespace Application.Interfaces
{
    public interface IMercaderiaService
    {
        MercaderiaResponse CreateMercaderia(MercaderiaRequest mercaderia);

        public void Add(Mercaderia mercaderia);
        public MercaderiaResponse Update(int mercaderiaId, MercaderiaRequest request);

        public MercaderiaResponse Delete(int mercaderiaId);
        public MercaderiaResponse GetMercaderiaById(int mercaderiaId);

        public List<MercaderiaGetResponse> GetAll(string? orden = null, string? nombre = null, int? tipo = null);

    }
}
