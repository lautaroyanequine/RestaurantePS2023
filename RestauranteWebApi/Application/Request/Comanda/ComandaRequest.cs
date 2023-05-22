namespace Application.Request.Comanda
{
    public class ComandaRequest
    {
        public IList<int> Mercaderias { get; set; }
        public int FormaEntrega { get; set; }
    }
}
