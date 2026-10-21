using api.Dtos.Doctor;
using api.Dtos.Paciente;
using api.DTOs.Doctor;
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


        //los doctores los puede alterar el admin nomas , en cambio el paciente de podra registrar en la db de forma manual, y luego su authentication y authorizzation
        [HttpPost("pacientes")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status201Created)]
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
            }catch(RespuestaError error)
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
            }catch (RespuestaError error)
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

        [HttpPut("pacientes/{id}")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
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
        public ActionResult Eliminar(int id)
        {
            try
            {
                _service.EliminarPaciente(id);
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

        [HttpPost("doctores")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status201Created)]
        public ActionResult<Respuesta> CrearDoctor([FromBody] CrearDoctorDTO crearDto)
        {
            try
            {
                var doctor = _service.CrearUnDoctor(crearDto);
                RespuestaExito exito = new RespuestaExito(
                    "Se creo correctamente!",
                    HttpStatusCode.Created,
                    doctor
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

        [HttpGet("doctores")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
        public ActionResult<Respuesta> ObtenerTodosLosDoctores()
        {
            try
            {
                var doctores = _service.ObtenerTodosLosDoctores();
                RespuestaExito exito = new RespuestaExito(
                    "Se obtuvieron correctamente!",
                    HttpStatusCode.OK,
                    doctores
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
        
        [HttpGet("doctores/{id}")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status404NotFound)]
        public ActionResult<Respuesta> ObtenerPorIdElDoctor(int id)
        {
            try
            {
                var doctor = _service.ObtenerUnDoctorPorId(id);
                RespuestaExito exito = new RespuestaExito(
                    "Se obtuvo correctamente!",
                    HttpStatusCode.OK,
                    doctor
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

        [HttpPut("doctores/{id}")]
        [ProducesResponseType(typeof(Respuesta), StatusCodes.Status200OK)]
        public ActionResult<Respuesta> ActualizarUnDoctorPorId(int id, [FromBody] ActualizarDoctorDTO dto)
        {
            try
            {
                var doctor = _service.ActualizarUnoPorId(id, dto);
                RespuestaExito exito = new RespuestaExito(
                    "Se actualizo correctamente!",
                    HttpStatusCode.OK,
                    doctor
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

        [HttpDelete("doctores/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult EliminarDoctor(int id)
        {
            try
            {
                _service.EliminarDoctor(id);
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