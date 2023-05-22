using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Request.Comanda;
using Application.Response.Comanda;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {

        private readonly IComandaService _service;

        public ComandaController(IComandaService service)
        {
            _service = service;
        }




        [HttpGet]
        [ProducesResponseType(typeof(ComandaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetAll([FromQuery] string? fecha = null)
        {

            try
            {
                var result = _service.GetAll(fecha);
                return new JsonResult(result);

            }
            catch (DatoInvalidoException ex)
            {
                return BadRequest(new { message = "La fecha es invalida.Asegurese de ingresar :DD-MM-AAAA o AAAA-MM-DD" });
            }




        }

        [HttpPost]
        [ProducesResponseType(typeof(ComandaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult CreateComanda(ComandaRequest request)
        {
            try
            {
                var result = _service.CreateComanda(request);
                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };

            }
            catch (IdInvalidoException ex)
            {
                return BadRequest(new { message = "Ingreso un ID invalido del mercaderia" });
            }
            catch (DatoInvalidoException exq)
            {
                return BadRequest(new { message = "Ingreso un ID de forma de entrega invalido" });
            }





        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ComandaGetResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]

        public IActionResult GetComandaById(Guid id)
        {
            try
            {
                var result = _service.GetComandaById(id);

                return new JsonResult(result);
            }
            catch (ElementoInexistenteException ex)
            {
                return NotFound(new { message = "No se encontro ninguna comanda" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }


        }
    }
}

