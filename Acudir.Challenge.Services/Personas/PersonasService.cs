using Acudir.Challenge.DA.DbContexts;
using Acudir.Challenge.DA.Repositories.Personas;
using Acudir.Challenge.DTOs.Personas;
using Acudir.Challenge.Models.Personas;
using AutoMapper;

namespace Acudir.Challenge.Services.Personas
{
    public class PersonasService : IPersonasService
    {
        private AcudirDbContext _dbContext;
        private IPersonasRepository _personasRepository;     
        private IMapper _mapper;

        public PersonasService(IMapper mapper, AcudirDbContext dbContext)
        {
            _dbContext = dbContext;
            _personasRepository = new PersonasRepository(dbContext); // Puede inyectarse de querer         
            _mapper = mapper;
        }

        public async Task<List<PersonaDTO>?> GetAll()
        {
            try
            {
                List<Persona>? personas = await _personasRepository.GetAll();
                List<PersonaDTO>? personasDTO = _mapper.Map<List<PersonaDTO>>(personas);
                return personasDTO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PersonaDTO?> Get(int personaId)
        {
            try
            {
                Persona? persona = await _personasRepository.Get(personaId);
                PersonaDTO? personaDTO = _mapper.Map<PersonaDTO>(persona);
                return personaDTO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PersonaDTO?> GetShuffle()
        {
            try
            {
                List<PersonaDTO>? personasDTO = await GetAll();
                var r = new Random();
                return personasDTO?.ElementAt(r.Next(0, personasDTO.Count()));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PersonaResultDTO> Delete(int personaId)
        {
            try
            {
                Persona? persona = await _personasRepository.Get(personaId);

                await _personasRepository.Delete(personaId);
                await _dbContext.SaveChangesAsync();

                return new PersonaResultDTO() // Puede responder algo más generico de querer
                {
                    Codigo = "ok",
                    Mensaje = "Persona Actualizada OK"
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }       
    }
}
