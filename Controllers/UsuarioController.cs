using api.Dtos.Paciente;
using api.DTOs.Paciente;
using api.Services;
using api.Utils;
using api.Utils.Respuestas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServices _service;
        public UsuarioController(UsuarioServices service)
        {
            _service = service;
        }

        [HttpPost("pacientes")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status400BadRequest)]
        public ActionResult<Respuesta> CrearPaciente([FromBody] CrearPacienteDTO crearDto)
        {
            try
            {
                var paciente = _service.CrearUnPaciente(crearDto);
                RespuestaExito exito = new RespuestaExito(
                    "Se creo correctamente!",
                    HttpStatusCode.Created,
                    paciente
                );

                return StatusCode((int)exito.CodigoEstado, exito.Res);
            }
            catch (Exception error)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Respuesta(error.Message)
                );
            }
        }

        [HttpGet("pacientes")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
        public ActionResult<Respuesta> ObtenerTodos()
        {
            try
            {
                var pacientes = _service.ObtenerTodosLosPacientes();
                RespuestaExito exito = new RespuestaExito(
                    "Se obtuvieron correctamente!",
                    HttpStatusCode.OK,
                    pacientes
                );

                return StatusCode((int)exito.CodigoEstado, exito.Res);
            }
            catch (Exception error)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Respuesta(error.Message)
                );
            }
        }

        [HttpGet("pacientes/{id}")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status404NotFound)]
        public ActionResult<Respuesta> ObtenerPorId(int id)
        {
            try
            {
                var paciente = _service.ObtenerUnoPorId(id);
                RespuestaExito exito = new RespuestaExito(
                    "Se obtuvo correctamente!",
                    HttpStatusCode.OK,
                    paciente
                );

                return StatusCode((int)exito.CodigoEstado, exito.Res);
            }
            catch (Exception error)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Respuesta(error.Message)
                );
            }
        }

        [HttpPut("pacientes/{id}")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status404NotFound)]
        public ActionResult<Respuesta> ActualizarUnoPorId(int id, [FromBody] ActualizarPacienteDTO dto)
        {
            try
            {
                var paciente = _service.ActualizarUnoPorId(id, dto);
                RespuestaExito exito = new RespuestaExito(
                    "Se actualizo correctamente!",
                    HttpStatusCode.OK,
                    paciente
                );

                return StatusCode((int)exito.CodigoEstado, exito.Res);
            }
            catch (Exception error)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Respuesta(error.Message)
                );
            }
        }

        [HttpDelete("pacientes/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status404NotFound)]
        public ActionResult Eliminar(int id)
        {
            try
            {
                _service.EliminarPaciente(id);
                return NoContent();
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