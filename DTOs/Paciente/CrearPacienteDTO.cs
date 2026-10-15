namespace api.Dtos.Paciente;

public class CrearPacienteDTO
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;
    public DateTime FecNac { get; set; }
    public string Telefono { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Contraseña { get; set; } = string.Empty;
    public string? ObraSocial { get; set; }
    public string? NroAfiliado { get; set; }

}