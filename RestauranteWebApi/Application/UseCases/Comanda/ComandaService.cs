using Application.Exceptions;
using Application.Interfaces;
using Application.Request.Comanda;
using Application.Response;
using Application.Response.Comanda;
using Application.Response.ComandaMercaderia;
using Application.Response.FormaEntrega;
using Application.Response.Mercaderia;
using Persistence.Database.Models;
using System.Globalization;

namespace Application.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaCommand _command;
        private readonly IComandaQuery _query;
        private readonly IComandaMercaderiaCommand _command2;
        private readonly IMercaderiaQuery _queryMercaderia;
        private readonly IFormaEntregaQuery _queryFormaEntrega;
        private readonly ITipoMercaderiaQuery _queryTipoMercaderia;


        public ComandaService(IComandaCommand command, IComandaQuery query, IComandaMercaderiaCommand comman, IMercaderiaQuery queryMercaderia, IFormaEntregaQuery formaEntregaQuery, ITipoMercaderiaQuery queryTipoMercaderia)
        {
            _command = command;
            _query = query;
            _command2 = comman;
            _queryMercaderia = queryMercaderia;
            _queryFormaEntrega = formaEntregaQuery;
            _queryTipoMercaderia = queryTipoMercaderia;
        }


        public ComandaResponse CreateComanda(ComandaRequest request)
        {
            var mercaderias = new List<MercaderiaComandaResponse>();
            var comandasMercaderia = new List<ComandaMercaderia>();
            var formaEntrega = _queryFormaEntrega.GetFormaEntrega(request.FormaEntrega);
            var id = new Guid();
            double total = 0;
            foreach (var IdMercaderia in request.Mercaderias)
            {
                var aux = _queryMercaderia.GetMercaderia(IdMercaderia);
                if (aux != null)
                {
                    mercaderias.Add(new MercaderiaComandaResponse
                    {
                        Id = aux.MercaderiaId,
                        Nombre = aux.Nombre,
                        Precio = aux.Precio,
                    });
                    total = total + aux.Precio;

                    var comMer = new ComandaMercaderia
                    {
                        ComandaId = id,
                        MercaderiaId = aux.MercaderiaId
                    };
                    comandasMercaderia.Add(comMer);
                }
                else
                {
                    throw new IdInvalidoException();
                }


            }

            if (formaEntrega == null) { throw new DatoInvalidoException(); }


            var comanda = new Comanda
            {
                ComandaId = id,
                FormaEntregaId = formaEntrega.FormaEntregaId,
                FormaEntrega = formaEntrega,
                PrecioTotal = (int)total,
                Fecha = DateTime.Now,
                ComandasMercaderia = comandasMercaderia

            };
            _command.InsertComanda(comanda);
            foreach (var item in comandasMercaderia)
            {
                item.ComandaMercaderiaId = 0;
                _command2.InsertComandaMercaderia(item);
            }


            return new ComandaResponse
            {
                Id = comanda.ComandaId,
                Mercaderias = mercaderias,
                FormaEntrega = new FormaEntregaResponse
                {
                    Id = formaEntrega.FormaEntregaId,
                    Descripcion = formaEntrega.Descripcion
                },
                Total = comanda.PrecioTotal,
                Fecha = comanda.Fecha,


            };

        }

        public void Delete(Guid comandaId)
        {
            _command.RemoveComanda(comandaId);
        }

      

        public List<ComandaResponse> GetAll(string? fecha = null)
        {
            DateTime fechaDateTime;
            string fechaFormatted = null;

            if (fecha != null)
            {
                if (DateTime.TryParseExact(fecha, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "dd-mm-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "dd/mm/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "dd-mm-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "yy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "yyyy/mm/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "yy/mm/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "yy/m/d", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "yyyy/m/d", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");
                else if (DateTime.TryParseExact(fecha, "yyyy-m-d", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDateTime)) fechaFormatted = fechaDateTime.ToString("yyyy-mm-dd");


                else throw new DatoInvalidoException();
            }


            var comandas = _query.GetList(fechaFormatted);
            var comandasResponses = new List<ComandaResponse>();
            var mercaderiaComandasResponses = new List<MercaderiaComandaResponse>();
            foreach (var comanda in comandas)
            {
                foreach (var comandaMercaderia in comanda.ComandasMercaderia)
                {
                    mercaderiaComandasResponses.Add(new MercaderiaComandaResponse
                    {
                        Id = comandaMercaderia.ComandaMercaderiaId,
                        Nombre = _queryMercaderia.GetMercaderia(comandaMercaderia.MercaderiaId).Nombre,
                        Precio = _queryMercaderia.GetMercaderia(comandaMercaderia.MercaderiaId).Precio
                    });
                }


            }

            foreach (var comanda in comandas)
            {
                comandasResponses.Add(new ComandaResponse
                {
                    Id = comanda.ComandaId,
                    Mercaderias = mercaderiaComandasResponses,
                    FormaEntrega = new FormaEntregaResponse
                    {
                        Id = _queryFormaEntrega.GetFormaEntrega(comanda.FormaEntregaId).FormaEntregaId,
                        Descripcion = _queryFormaEntrega.GetFormaEntrega(comanda.FormaEntregaId).Descripcion
                    },
                    Total = comanda.PrecioTotal,
                    Fecha = comanda.Fecha
                });
            }

            return comandasResponses;
        }

        public ComandaGetResponse GetComandaById(Guid comandaId)
        {
            var comanda = _query.GetComanda(comandaId);
            IList<MercaderiaGetResponse> mercaderias = new List<MercaderiaGetResponse>();
            if (comanda == null) throw new ElementoInexistenteException();

            foreach (var mercaderia in comanda.ComandasMercaderia)
            {
                var mercaderiaAux = _queryMercaderia.GetMercaderia(mercaderia.MercaderiaId);
                var mercaderiaGetResponse = new MercaderiaGetResponse
                {
                    Id = mercaderiaAux.MercaderiaId,
                    Nombre = mercaderiaAux.Nombre,
                    Tipo = new TipoMercaderiaResponse
                    {
                        Id = mercaderiaAux.TipoMercaderiaId,
                        Descripcion = _queryTipoMercaderia.GetTipoMercaderia(mercaderiaAux.TipoMercaderiaId).Descripcion


                    },
                    Imagen = mercaderiaAux.Imagen

                };
                mercaderias.Add(mercaderiaGetResponse);
            }


            return new ComandaGetResponse
            {
                Id = comanda.ComandaId,
                Mercaderias = mercaderias,
                FormaEntrega = new FormaEntregaResponse
                {
                    Id = comanda.FormaEntregaId,
                    Descripcion = _queryFormaEntrega.GetFormaEntrega(comanda.FormaEntregaId).Descripcion

                },
                Total = comanda.PrecioTotal,
                Fecha = comanda.Fecha

            };
        }

        public void Update(Comanda comanda)
        {
            _command.ActualizeComanda(comanda);
        }



    }
}
