using Application.Response.ComandaMercaderia;
using Application.Response.FormaEntrega;

namespace Application.Response.Comanda
{
    public class ComandaResponse
    {
        public Guid Id { get; set; }
        public ICollection<MercaderiaComandaResponse> Mercaderias { get; set; }
        public FormaEntregaResponse FormaEntrega { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }

    }
}
