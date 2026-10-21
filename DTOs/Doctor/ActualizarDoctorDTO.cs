using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Doctor
{
    public class ActualizarDoctorDTO
    {
        [MinLength(3, ErrorMessage = "Debe tener al menos 3 letras el nombre")]
        public string? Nombre { get; set; }

        [MinLength(3, ErrorMessage = "Debe tener al menos 3 letras el apellido")]
        public string? Apellido { get; set; }

        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "El teléfono debe contener solo 10 u 11 dígitos")]
        public string? Telefono { get; set; }

        [RegularExpression(@"^\d{7,8}$", ErrorMessage = "El DNI debe contener solo 7 u 8 dígitos")]
        public string? Dni { get; set; }

        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string? Email { get; set; }

        [MinLength(6, ErrorMessage = "Como mínimo 6 caracteres")]
        public string? Contraseña { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "La especialidad debe tener entre 3 y 100 caracteres")]
        public string? Especialidad { get; set; }
    }
}