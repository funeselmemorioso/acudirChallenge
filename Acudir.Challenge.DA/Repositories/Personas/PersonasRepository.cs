using Acudir.Challenge.DA.DbContexts;
using Acudir.Challenge.Models.Personas;
using Microsoft.EntityFrameworkCore;

namespace Acudir.Challenge.DA.Repositories.Personas
{
    public class PersonasRepository : IPersonasRepository
    {
        AcudirDbContext _dbContext;

        public PersonasRepository(AcudirDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Persona>?> GetAll()
        {
            try
            {
                return await _dbContext.Personas.Where(p=>p.Activa).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Persona?> Get(int personaId)
        {
            try
            {
                return await _dbContext.Personas.FirstOrDefaultAsync(p=>p.PersonaId == personaId && p.Activa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }     

        public async Task<Persona?> Delete(int personaId)
        {
            try
            {
                Persona? persona = await _dbContext.Personas
                      .Where(x => x.PersonaId == personaId)
                      .FirstOrDefaultAsync();

                if (persona is not null)
                {
                    persona.Activa = false;
                }

                return persona;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
