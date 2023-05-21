namespace Application.Response.Mercaderia
{
    public class MercaderiaGetResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public TipoMercaderiaResponse Tipo { get; set; }

        public string Imagen { get; set; }
    }
}
