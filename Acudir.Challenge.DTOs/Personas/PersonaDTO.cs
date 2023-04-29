namespace Acudir.Challenge.DTOs.Personas
{
    public class PersonaDTO
    {
        public int PersonaId { get; set; }
        public String? Nombre { get; set; }
        public String? Apellido { get; set; }
        public String? Documento { get; set; }
        public bool Activa { get; set; }
    }
}
