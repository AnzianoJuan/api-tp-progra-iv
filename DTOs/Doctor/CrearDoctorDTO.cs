
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Doctor;

public class CrearDoctorDTO
{
    [Required(ErrorMessage = "Debe ser obligatorio el nombre")]
    [MinLength(3, ErrorMessage = "Debe tener al menos 3 letras el nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe ser obligatorio el apellido")]
    [MinLength(3, ErrorMessage = "Debe tener al menos 3 letras el apellido")]
    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "El DNI es obligatorio")]
    [MinLength(7, ErrorMessage = "Debe tener como mínimo 7 dígitos")]
    [MaxLength(8, ErrorMessage = "Debe tener como máximo 8 dígitos")]
    public string Dni { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    [DataType(DataType.Date)]
    public DateOnly FecNac { get; set; }

    [Required(ErrorMessage = "Debe dejar su número de teléfono")]
    [MinLength(10, ErrorMessage = "Debe tener mínimo 10 dígitos")]
    [MaxLength(11, ErrorMessage = "Debe tener máximo 11 dígitos")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe tener obligatoriamente una contraseña")]
    [MinLength(6, ErrorMessage = "Como mínimo 6 caracteres")]
    public string Contraseña { get; set; } = string.Empty;

    [Required(ErrorMessage = "La especialidad es obligatoria")]
    public string Especialidad { get; set; } = string.Empty;
}
