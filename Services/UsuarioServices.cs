using api.Models;
using api.Utils.Respuestas;
using api.Dtos.Paciente;
using System.Net;

namespace api.Services
{
    public class UsuarioServices
    {

        //lista de prueba de PAcientes
        private static readonly List<Paciente> _pacientes = new()
        {
            new Paciente() { Id = 1, Nombre = "Jorge", Apellido = "Rosettani viejo nomas" , Dni = "777",FecNac=DateTime.Today, Telefono= "claro 343434", Email="jorg@",Contraseña="top secret",IsAdmin = false,FechaCreacion=DateTime.Now,ObraSocial="osde"},
            new Paciente() { Id = 2, Nombre = "juani", Apellido = "Rosettani viejo nomas" , Dni = "777",FecNac=DateTime.Today, Telefono= "claro 343434", Email="juan@",Contraseña="top secret",IsAdmin = false,FechaCreacion=DateTime.Now,ObraSocial="osde"},
            new Paciente() { Id = 3, Nombre = "claudia", Apellido = "Rosettani viejo nomas" , Dni = "777",FecNac=DateTime.Today, Telefono= "claro 343434", Email="claude@",Contraseña="top secret",IsAdmin = false,FechaCreacion=DateTime.Now,NroAfiliado="49-99-07"},
        };

        public List<Paciente> ObtenerTodosLosPacientes() => _pacientes;

        public Paciente ObtenerUnoPorId(int id)
        {
            var paciente = _pacientes.FirstOrDefault((p) => p.Id == id);
            if (paciente == null)
            {
                throw new RespuestaError(
                    $"El paciente con id = {id} no se encontro",
                    HttpStatusCode.NotFound
                );
            }
            return paciente;
        }

        public Paciente CrearUno(CrearPacienteDTO dto)
        {
            int maxId = _pacientes.Max(p => p.Id);
            var paciente = new Paciente()
            {
                Id = maxId + 1,
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

            return paciente;
           
        }


    }
}
