using api.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Dtos.Paciente;
using api.Utils.Respuestas;
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


       


    }
}