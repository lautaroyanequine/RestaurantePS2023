using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Application.Response.Mercaderia;
using Persistence.Database.Models;

namespace Application.Services
{
    public class MercaderiaService : IMercaderiaService
    {
        private readonly IMercaderiaCommand _command;
        private readonly IMercaderiaQuery _query;
        private readonly ITipoMercaderiaQuery _queryTipoMercaderia;
        private readonly IComandaMercaderiaService _queryComandaMercaderia;



        public MercaderiaService(IMercaderiaCommand command, IMercaderiaQuery query, ITipoMercaderiaQuery queryTipoMercaderia, IComandaMercaderiaService queryComandaMercaderia)
        {
            _command = command;
            _query = query;
            _queryTipoMercaderia = queryTipoMercaderia;
            _queryComandaMercaderia = queryComandaMercaderia;
        }
        public void Add(Mercaderia mercaderia)
        {
            _command.InsertMercaderia(mercaderia);
        }

        public MercaderiaResponse CreateMercaderia(MercaderiaRequest request)
        {
            if (_query.GetMercaderia(request.Nombre.ToUpper()) == null)
            {
                if (_queryTipoMercaderia.GetTipoMercaderia(request.Tipo) == null) throw new IdInvalidoException();

                if (request.Precio <= 0) throw new PrecioInvalidoException();
                if (request.Preparacion.Length <= 10) throw new PreparacionException();
                if (request.Ingredientes.Length <= 10) throw new IngredientesException();

                if (!request.Imagen.Contains(".jpg") && !request.Imagen.Contains(".png")) throw new ImagenException();

                var mercaderia = new Mercaderia
                {
                    Nombre = request.Nombre,
                    Precio = request.Precio,
                    Preparacion = request.Preparacion,
                    Ingredientes = request.Ingredientes,
                    Imagen = request.Imagen,
                    TipoMercaderiaId = request.Tipo,
                };
                _command.InsertMercaderia(mercaderia);
                return new MercaderiaResponse
                {
                    Id = mercaderia.MercaderiaId,
                    Nombre = mercaderia.Nombre,

                    Tipo = new TipoMercaderiaResponse
                    {

                        Id = _queryTipoMercaderia.GetTipoMercaderia(request.Tipo).TipoMercaderiaId,
                        Descripcion = _queryTipoMercaderia.GetTipoMercaderia(request.Tipo).Descripcion
                    },
                    Precio = mercaderia.Precio,
                    Preparacion = mercaderia.Preparacion,
                    Ingredientes = mercaderia.Ingredientes,
                    Imagen = mercaderia.Imagen,



                };
            }
            else throw new NombreExisteException();

        }

        public MercaderiaResponse Delete(int mercaderiaId)
        {
            IList<ComandaMercaderia> encomiendas = _queryComandaMercaderia.GetAll();
            foreach (var encomienda in encomiendas)
            {
                if (encomienda.MercaderiaId == mercaderiaId) throw new IdInvalidoException(); //409
            }

            var mercaderia = _command.RemoveMercaderia(mercaderiaId);
            if (mercaderia == null) throw new ElementoInexistenteException();
            return new MercaderiaResponse
            {
                Id = mercaderiaId,
                Nombre = mercaderia.Nombre,

                Tipo = new TipoMercaderiaResponse
                {

                    Id = _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId).TipoMercaderiaId,
                    Descripcion = _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId).Descripcion
                },
                Precio = mercaderia.Precio,
                Preparacion = mercaderia.Preparacion,
                Ingredientes = mercaderia.Ingredientes,
                Imagen = mercaderia.Imagen,
            };
        }



      

        public List<MercaderiaGetResponse> GetAll(string? orden = null, string? nombre = null, int? tipo = null)
        {
            if(orden != null)
            {
                if (orden.ToUpper() != "ASC" && orden.ToUpper() != "DESC" ) throw new DatoInvalidoException();
            }
            if (tipo != null)
            {
                if (_queryTipoMercaderia.GetTipoMercaderia((int)tipo) == null) throw new IdInvalidoException();

            }

            var mercaderias = _query.GetListMercaderia(orden, nombre, tipo);
            var mercaderiasResponse = new List<MercaderiaGetResponse>();

            foreach (var mercaderia in mercaderias)
            {
                mercaderiasResponse.Add(new MercaderiaGetResponse
                {
                    Id = mercaderia.MercaderiaId,
                    Nombre = mercaderia.Nombre,

                    Tipo = new TipoMercaderiaResponse
                    {

                        Id = _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId).TipoMercaderiaId,
                        Descripcion = _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId).Descripcion
                    },
                    Precio = mercaderia.Precio,
                    Imagen = mercaderia.Imagen,
                });
            }

            return mercaderiasResponse;
        }

        public MercaderiaResponse GetMercaderiaById(int mercaderiaId)
        {
            var mercaderia = _query.GetMercaderia(mercaderiaId);
            if (mercaderia != null)
            {
                return new MercaderiaResponse
                {
                    Id = mercaderia.MercaderiaId,
                    Nombre = mercaderia.Nombre,

                    Tipo = new TipoMercaderiaResponse
                    {

                        Id = _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId).TipoMercaderiaId,
                        Descripcion = _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId).Descripcion
                    },
                    Precio = mercaderia.Precio,
                    Preparacion = mercaderia.Preparacion,
                    Ingredientes = mercaderia.Ingredientes,
                    Imagen = mercaderia.Imagen
                };

            }
            else throw new ElementoInexistenteException();

        }

   

        public MercaderiaResponse Update(int mercaderiaId, MercaderiaRequest request)
        {

            if (_queryTipoMercaderia.GetTipoMercaderia(request.Tipo) == null) throw new IdInvalidoException();
            if (request.Precio <= 0) throw new PrecioInvalidoException();
            if (request.Preparacion.Length <= 10) throw new PreparacionException();
            if (request.Ingredientes.Length <= 10) throw new IngredientesException();
            if (!request.Imagen.Contains(".jpg") && !request.Imagen.Contains(".png")) throw new ImagenException();
            if (_query.GetMercaderia(request.Nombre.ToUpper()) != null) throw new NombreExisteException();

            var mercaderia = _command.ActualizeMercaderia(mercaderiaId, request);
            if (mercaderia != null)
            {


                return new MercaderiaResponse
                {
                    Id = mercaderiaId,
                    Nombre = mercaderia.Nombre,

                    Tipo = new TipoMercaderiaResponse
                    {

                        Id = _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId).TipoMercaderiaId,
                        Descripcion = _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId).Descripcion
                    },
                    Precio = mercaderia.Precio,
                    Preparacion = mercaderia.Preparacion,
                    Ingredientes = mercaderia.Ingredientes,
                    Imagen = mercaderia.Imagen,
                };
            }
            else throw new ElementoInexistenteException();

        }


    }
}
