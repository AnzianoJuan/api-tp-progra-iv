using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace api.Models
{
    public class Paciente : Usuario
    {

       

        [ForeignKey(nameof(ObraSocial))]
        public int? IdObraSocial { get; set; }

        public ObraSocial? ObraSocial { get; set; }
        public string? NroAfiliado { get; set; }
        public List<Turno> Turnos { get; set; } = new();
    }
    
}
