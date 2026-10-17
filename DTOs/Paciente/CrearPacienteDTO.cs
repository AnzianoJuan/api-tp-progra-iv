using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Paciente;

public class CrearPacienteDTO
{

    [Required(ErrorMessage ="Debe ser obligatorio el nombre")]
    [MinLength(3,ErrorMessage ="Debe tener al menos 3 letras el nombre")]
    public string Nombre { get; set; } = string.Empty;

    
    [Required(ErrorMessage ="Debe ser obligatorio el apellido")]
    [MinLength(3,ErrorMessage ="Debe tener al menos 3 letras el apellido")]
    public string Apellido { get; set; } = string.Empty;

    
    [Required(ErrorMessage = "El DNI es obligatorio")]
    [MinLength(7,ErrorMessage ="debe tener como minimo 7 digitos")]
    [MaxLength(8, ErrorMessage = "debe tener como maximo 8 digitos")]
    public string Dni { get; set; } = string.Empty;


    [Required(ErrorMessage ="debe ser obligatira la fecha de nacimiento")]
    [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
    public DateOnly FecNac { get; set; }

    [Required(ErrorMessage = "Debe dejar su numero de telefono")]
    [MinLength(10,ErrorMessage ="debe tener minimo 10 digitos")]
    [MaxLength(11, ErrorMessage = "debe tener maximo 11 digitos")]
    public string Telefono { get; set; } = string.Empty;


    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage ="Debe tener obligatoriamente una contraseña")]
    [MinLength(6,ErrorMessage ="Como minimo 6 caracteres")]
    public string Contraseña { get; set; } = string.Empty; // estaria hasehada 
    public string? ObraSocial { get; set; } 
    public string? NroAfiliado { get; set; }

}