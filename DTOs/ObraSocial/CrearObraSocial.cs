using System.ComponentModel.DataAnnotations;

namespace api.Dtos.ObraSocial;

public class CrearObraSocialDTO
{
    [Required(ErrorMessage = "El nombre de la obra social es obligatorio")]
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}