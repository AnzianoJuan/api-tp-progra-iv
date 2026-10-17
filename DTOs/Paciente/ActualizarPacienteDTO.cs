using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Paciente
{
    public class ActualizarPacienteDTO
    {


        [MinLength(3, ErrorMessage = "Debe tener al menos 3 letras el nombre")]
        public string? Nombre { get; set; }
        [MinLength(3, ErrorMessage = "Debe tener al menos 3 letras el apellido")]
        public string? Apellido { get; set; }

        [MinLength(10, ErrorMessage = "debe tener minimo 10 digitos")]
        [MaxLength(11, ErrorMessage = "debe tener maximo 11 digitos")]
        public string? Telefono { get; set; }

        [MinLength(7, ErrorMessage = "debe tener como minimo 7 digitos")]
        [MaxLength(8, ErrorMessage = "debe tener como maximo 8 digitos")]
        public string? Dni { get; set; }
        /*
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateOnly? FecNac { get; set; }
        */ 
        // Actualizar la fecha de nacimiento genera un error despues.

        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string? Email { get; set; }

        [MinLength(6, ErrorMessage = "Como minimo 6 caracteres")]
        public string? Contraseña { get; set; }  // Deberia estar hasehada, no se si se deberia actualizar la password por aca...  
        public string? ObraSocial { get; set; }
        public string? NroAfiliado { get; set; }
    }
}