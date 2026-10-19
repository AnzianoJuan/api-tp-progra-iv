using api.Models;
using api.Utils.Respuestas;
using api.Dtos.Paciente;
using System.Net;
using api.Config;
using api.DTOs.Paciente;

namespace api.Services
{
    public class UsuarioServices
    {

        //aca estaria la db :

        private readonly AppDbContext _db;


        public UsuarioServices(AppDbContext db)
        {
            _db = db;
        }

        public List<PacienteDTO> ObtenerTodosLosPacientes()
        {
            var lista = _db.Pacientes.Select((p) => new PacienteDTO()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Dni = p.Dni,
                NroAfiliado = p.NroAfiliado,
                //ObraSocial = p.ObraSocial.Nombre,
            }).ToList();
            return lista;
        }

        public Paciente ObtenerUnoPorId(int id)
        {
            var paciente = _db.Pacientes.FirstOrDefault((p) => p.Id == id);
            if (paciente == null)
            {
                throw new RespuestaError(
                    $"El paciente con id = {id} no se encontro",
                    HttpStatusCode.NotFound
                );
            }
            return paciente;
        }

        public Paciente CrearUnPaciente(CrearPacienteDTO dto)
        {
            var paciente = new Paciente()
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni,
                Email = dto.Email,
                Contraseña = dto.Contraseña,
                FechaCreacion = DateTime.Now,
                FecNac = dto.FecNac,
                NroAfiliado = dto.NroAfiliado,
                //ObraSocial = dto.ObraSocial,
                Telefono = dto.Telefono,
            };
            _db.Pacientes.Add(paciente);
            _db.SaveChanges();
            return paciente;
           
        }

           public Paciente ActualizarUnoPorId(int id, ActualizarPacienteDTO dto)
        {
            Paciente paciente = ObtenerUnoPorId(id);

            if (dto.Nombre != null)
            {
                paciente.Nombre = dto.Nombre;
            }
            if (dto.Apellido != null)
            {
                paciente.Apellido = dto.Apellido;
            }
            if (dto.Dni != null)
            {
                paciente.Dni = dto.Dni;
            }
            if (dto.Email != null)
            {
                paciente.Email = dto.Email;
            }
            if (dto.Contraseña != null)
            {
                paciente.Contraseña = dto.Contraseña;
            }
            if (dto.NroAfiliado != null)
            {
                paciente.NroAfiliado = dto.NroAfiliado;
            }
            if (dto.ObraSocial != null)
            {
                //paciente.ObraSocial = dto.ObraSocial;
            }
            if (dto.Telefono != null)
            {
                paciente.Telefono = dto.Telefono;
            }

            _db.Pacientes.Update(paciente);
            _db.SaveChanges();

            return paciente;
        }

        public void EliminarPaciente(int id)
        {
            Paciente paciente = ObtenerUnoPorId(id);
            _db.Pacientes.Remove(paciente);
            _db.SaveChanges();
        }


    }
}
