namespace api.Models
{
    public class Paciente : Usuario
    {
        public double Dni { get; set; }
        // De Fecnac tambien se puede sacar la edad.
        public DateTime FecNac { get; set; }

        public string Telefono { get; set; } = string.Empty;
        // Obra Social y Numero de Afiliado son posibles string para incluir las consultas particulares,
        // Las consultas particulares son las que no tinen obra social.
        public string? ObraSocial { get; set; } = string.Empty;
        public string? NroAfiliado { get; set; } = string.Empty;

        public List<Turno> Turnos { get; set; } = new();
    }
    }
}
