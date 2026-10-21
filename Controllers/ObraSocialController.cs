using api.Dtos.ObraSocial;
using api.Services;
using api.Utils.Respuestas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ObraSocialController : ControllerBase
    {
        private readonly ObraSocialServices _service;

        public ObraSocialController(ObraSocialServices service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status201Created)]
        public ActionResult<Respuesta> CrearObraSocial(
            [FromBody] CrearObraSocialDTO crearDto)
        {
            try
            {
                var obraSocial = _service.CrearObraSocial(crearDto);
                var exito = new RespuestaExito(
                    "La obra social se creó correctamente.",
                    HttpStatusCode.Created,
                    obraSocial
                );

                return StatusCode((int)exito.CodigoEstado, exito.Res);
            }
            catch (RespuestaError error)
            {
                return StatusCode((int)error.CodigoEstado, error.Res);
            }
            catch (Exception error)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Respuesta(error.Message)
                );
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
        public ActionResult<Respuesta> ObtenerTodas()
        {
            try
            {
                var obrasSociales = _service.ObtenerTodasLasObrasSociales();
                var exito = new RespuestaExito(
                    "Las obras sociales se obtuvieron correctamente.",
                    HttpStatusCode.OK,
                    obrasSociales
                );

                return StatusCode((int)exito.CodigoEstado, exito.Res);
            }
            catch (RespuestaError error)
            {
                return StatusCode((int)error.CodigoEstado, error.Res);
            }
            catch (Exception error)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Respuesta(error.Message)
                );
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status404NotFound)]
        public ActionResult<Respuesta> ObtenerPorId(int id)
        {
            try
            {
                var obraSocial = _service.ObtenerUnoPorId(id);
                var exito = new RespuestaExito(
                    "La obra social se obtuvo correctamente.",
                    HttpStatusCode.OK,
                    obraSocial
                );

                return StatusCode((int)exito.CodigoEstado, exito.Res);
            }
            catch (RespuestaError error)
            {
                return StatusCode((int)error.CodigoEstado, error.Res);
            }
            catch (Exception error)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Respuesta(error.Message)
                );
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
        public ActionResult<Respuesta> ActualizarPorId(
            int id,
            [FromBody] ActualizarObraSocialDTO dto)
        {
            try
            {
                var obraSocial = _service.ActualizarUnoPorId(id, dto);
                var exito = new RespuestaExito(
                    "La obra social se actualizó correctamente.",
                    HttpStatusCode.OK,
                    obraSocial
                );

                return StatusCode((int)exito.CodigoEstado, exito.Res);
            }
            catch (RespuestaError error)
            {
                return StatusCode((int)error.CodigoEstado, error.Res);
            }
            catch (Exception error)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Respuesta(error.Message)
                );
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Eliminar(int id)
        {
            try
            {
                _service.EliminarObraSocial(id);
                return NoContent();
            }
            catch (RespuestaError error)
            {
                return StatusCode((int)error.CodigoEstado, error.Res);
            }
            catch (Exception error)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Respuesta(error.Message)
                );
            }
        }
    }
}