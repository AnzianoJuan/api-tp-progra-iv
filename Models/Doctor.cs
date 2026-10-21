namespace api.Models;

public class Doctor : Usuario
{
    public string Especialidad { get; set; } = string.Empty;

    public List<Turno> Turnos { get; set; } = new();
}