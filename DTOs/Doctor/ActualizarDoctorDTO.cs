
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Doctor
{
    public class ActualizarDoctorDTO
    {
        [MinLength(3, ErrorMessage = "Debe tener al menos 3 letras el nombre")]
        public string? Nombre { get; set; }

        [MinLength(3, ErrorMessage = "Debe tener al menos 3 letras el apellido")]
        public string? Apellido { get; set; }

        [MinLength(10, ErrorMessage = "Debe tener mínimo 10 dígitos")]
        [MaxLength(11, ErrorMessage = "Debe tener máximo 11 dígitos")]
        public string? Telefono { get; set; }

        [MinLength(7, ErrorMessage = "Debe tener como mínimo 7 dígitos")]
        [MaxLength(8, ErrorMessage = "Debe tener como máximo 8 dígitos")]
        public string? Dni { get; set; }

        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string? Email { get; set; }

        [MinLength(6, ErrorMessage = "Como mínimo 6 caracteres")]
        public string? Contraseña { get; set; }

        public string? Especialidad { get; set; }
    }
}
