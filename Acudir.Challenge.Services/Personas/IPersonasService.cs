using Acudir.Challenge.DTOs.Personas;

namespace Acudir.Challenge.Services.Personas
{
    public interface IPersonasService
    {
        Task<List<PersonaDTO>?> GetAll();
        Task<PersonaDTO?> Get(int personaId);
        Task<PersonaDTO?> GetShuffle();
        Task<PersonaResultDTO> Delete(int personaId);
    }
}
