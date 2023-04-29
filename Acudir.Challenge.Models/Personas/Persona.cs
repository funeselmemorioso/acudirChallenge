using System.ComponentModel.DataAnnotations;

namespace Acudir.Challenge.Models.Personas
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public String? Nombre { get; set; }
        public String? Apellido { get; set; }
        public String? Documento { get; set; }
        public bool Activa { get; set; }
    }
}
