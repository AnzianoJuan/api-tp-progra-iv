using System.ComponentModel.DataAnnotations;

namespace api.Dtos.ObraSocial;

public class ActualizarObraSocialDTO
{
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
    public string? Nombre { get; set; }

    public bool? IsActive { get; set; }
}