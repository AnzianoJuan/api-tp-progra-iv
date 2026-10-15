namespace api.Models
{
    public class Paciente : Usuario
    {
        // Obra Social y Numero de Afiliado son posibles string? para incluir las consultas particulares,
        // Las consultas particulares son las que no tinen obra social.
        public string? ObraSocial { get; set; } = string.Empty;
        public string? NroAfiliado { get; set; } = string.Empty;

        public List<Turno> Turnos { get; set; } = new();
    }
    
}
