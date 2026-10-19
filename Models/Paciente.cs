namespace api.Models
{
    public class Paciente : Usuario
    {

        // Obra Social y Numero de Afiliado son posibles string? para incluir las consultas particulares,
        // Las consultas particulares son las que no tinen obra social.
        public ObraSocial? ObraSocial { get; set; } = null!;
        public string? NroAfiliado { get; set; }
        //public List<Turno> Turnos { get; set; } = new();
    }
    
}
