
namespace api.DTOs.Paciente;

public class PacienteDTO
{

    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;

    public string? ObraSocial { get; set; }
    public string? NroAfiliado { get; set; }

}