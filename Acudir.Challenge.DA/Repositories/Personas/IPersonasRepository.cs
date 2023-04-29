using Acudir.Challenge.Models.Personas;

namespace Acudir.Challenge.DA.Repositories.Personas
{
    public interface IPersonasRepository
    {
        Task<List<Persona>?> GetAll();
        Task<Persona?> Get(int personaId);
        Task<Persona?> Delete(int personaId);
    }
}
