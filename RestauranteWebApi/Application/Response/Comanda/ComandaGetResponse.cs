using Application.Response.FormaEntrega;
using Application.Response.Mercaderia;

namespace Application.Response.Comanda
{
    public class ComandaGetResponse
    {
        public Guid Id { get; set; }
        public IList<MercaderiaGetResponse> Mercaderias { get; set; }
        public FormaEntregaResponse FormaEntrega { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
