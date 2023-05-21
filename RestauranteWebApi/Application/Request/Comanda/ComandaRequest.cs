namespace Application.Request.Comanda
{
    public class ComandaRequest
    {
        public IList<int> Mercaderia { get; set; }
        public int FormaEntrega { get; set; }
    }
}
