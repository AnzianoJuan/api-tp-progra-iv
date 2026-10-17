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

        //lista de prueba de PAcientes
        private static readonly List<Paciente> _pacientes = new()
        {
            new Paciente() { Id = 1, Nombre = "Jorge", Apellido = "Rosettani viejo nomas" , Dni = "777",FecNac = DateOnly.FromDateTime(DateTime.Today), Telefono= "claro 343434", Email="jorg@",Contraseña="top secret",IsAdmin = false,FechaCreacion=DateTime.Now,ObraSocial="osde"},
            new Paciente() { Id = 2, Nombre = "juani", Apellido = "Rosettani viejo nomas" , Dni = "777",FecNac = DateOnly.FromDateTime(DateTime.Today), Telefono= "claro 343434", Email="juan@",Contraseña="top secret",IsAdmin = false,FechaCreacion=DateTime.Now,ObraSocial="osde"},
            new Paciente() { Id = 3, Nombre = "claudia", Apellido = "Rosettani viejo nomas" , Dni = "777",FecNac = DateOnly.FromDateTime(DateTime.Today), Telefono= "claro 343434", Email="claude@",Contraseña="top secret",IsAdmin = false,FechaCreacion=DateTime.Now,NroAfiliado="49-99-07"},
        };


        public UsuarioServices(AppDbContext db)
        {
            _db = db;
        }

        public List<Paciente> ObtenerTodosLosPacientes() => _pacientes;

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
                ObraSocial = dto.ObraSocial,
                Telefono = dto.Telefono,
            };
            _db.Pacientes.Add(paciente);
            _pacientes.Add(paciente);//dejamos esta de prueba por ahora
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
                paciente.ObraSocial = dto.ObraSocial;
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
