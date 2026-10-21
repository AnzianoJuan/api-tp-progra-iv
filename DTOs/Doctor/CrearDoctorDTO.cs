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
    [RegularExpression(@"^\d{7,8}$", ErrorMessage = "El DNI debe contener solo 7 u 8 dígitos")]
    public string Dni { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    [DataType(DataType.Date)]
    public DateOnly FecNac { get; set; }

    [Required(ErrorMessage = "Debe dejar su número de teléfono")]
    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "El teléfono debe contener solo 10 u 11 dígitos")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe tener obligatoriamente una contraseña")]
    [MinLength(6, ErrorMessage = "Como mínimo 6 caracteres")]
    public string Contraseña { get; set; } = string.Empty;

    [Required(ErrorMessage = "La especialidad es obligatoria")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "La especialidad debe tener entre 3 y 100 caracteres")]
    public string Especialidad { get; set; } = string.Empty;
}