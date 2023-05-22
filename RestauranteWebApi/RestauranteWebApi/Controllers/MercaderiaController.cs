using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Application.Response.Mercaderia;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MercaderiaController : ControllerBase
    {

        private readonly IMercaderiaService _service;

        public MercaderiaController(IMercaderiaService service)
        {
            _service = service;
        }



        [HttpGet]
        [ProducesResponseType(typeof(MercaderiaGetResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetAll([FromQuery] int? tipo = null, string? nombre = null, string? orden = null)
        {
            try
            {
                var result = _service.GetAll(orden, nombre, tipo);
                return new JsonResult(result);

            }
            catch (DatoInvalidoException ex)
            {
                return BadRequest(new { message = "El valor del orden es inválido. Solo se permite 'ASC' o 'DESC" });

            }
            catch (IdInvalidoException elementoInexistente)
            {
                return BadRequest(new { message = "El tipo de mercaderia ingresado no existe" });

            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(MercaderiaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult CreateMercaderia(MercaderiaRequest request)
        {
            try
            {
                var result = _service.CreateMercaderia(request);
                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };

            }
            catch (NombreExisteException nombreExistente)
            {
                return Conflict(new { message = "No se pudo crear porque ya existe una mercadería con ese nombre" });

            }
            catch (IdInvalidoException idInvalido)
            {
                return BadRequest(new { message = "No se pudo crear porque el ID ingresado del Tipo de Mercaderia es invalido/no existe" });

            }
            catch (ImagenException img)
            {
                return BadRequest(new { message = "La imagen debe ser .png o .jpg" });


            }
            catch (PreparacionException pre)
            {
                return BadRequest(new { message = "La prepraracion debe tener minimamente mas de 10 caracteres" });
            }
            catch (IngredientesException ing)
            {
                return BadRequest(new { message = " Los ingredientes deben tener mas de 10 caracteres" });
            }
            catch (PrecioInvalidoException)
            {
                return BadRequest(new { message = "Debe poner un precio valido" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]

        public IActionResult GetMercaderiaById(int id)
        {
            try
            {
                var result = _service.GetMercaderiaById(id);
                return new JsonResult(result);

            }

            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "No se encontro la mercaderia solicitada" });

            }




        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]


        public IActionResult UpdateMercaderia(int id, MercaderiaRequest request)
        {
            try
            {
                var result = _service.Update(id, request);
                return new JsonResult(result);
            }
            catch (IdInvalidoException idInvalido)
            {
                return BadRequest(new { message = "No se pudo modificar porque el ID ingresado de Tipo es invalido/no existe" });
            }
            catch (NombreExisteException elementoInexistente)
            {
                return Conflict(new { message = "Ya existe una mercaderia con el nombre que desea ingresar" });
            }
            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "El elemento que desea modificar no existe" });
            }
            catch (ImagenException img)
            {
                return BadRequest(new { message = "La imagen debe ser .png o .jpg" });
            }
            catch (PreparacionException pre)
            {
                return BadRequest(new { message = "La prepraracion debe tener minimamente mas de 10 caracteres" });
            }
            catch (IngredientesException ing)
            {
                return BadRequest(new { message = " Los ingredientes deben tener mas de 10 caracteres" });
            }
            catch (PrecioInvalidoException)
            {
                return BadRequest(new { message = "Debe poner un precio valido" });
            }
            catch(Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeleteMercaderia(int id)
        {
            try
            {
                var result = _service.Delete(id);
                return new JsonResult(result);
            }
            catch (IdInvalidoException idInvalido)
            { return Conflict(new { message = "No se pudo eliminar esta mercaderia porque una encomienda depende de ella" }); }
            catch (ElementoInexistenteException elementoInexistente)
            { return BadRequest(new { message = "No existe la mercaderia que quiere eliminar" }); }
        }
    }
}