
using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Dtos.Paciente;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly UsuarioServices _service;

        public PacientesController(UsuarioServices service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(_service.ObtenerTodosLosPacientes());
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            return Ok(_service.ObtenerUnoPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] CrearPacienteDTO dto)
        {
            return Ok(_service.ModificarPaciente(id, dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            _service.EliminarPaciente(id);
            return NoContent();
        }
    }
}
