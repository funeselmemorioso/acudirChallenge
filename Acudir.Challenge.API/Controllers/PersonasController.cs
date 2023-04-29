using Acudir.Challenge.DTOs.Personas;
using Acudir.Challenge.Services.Personas;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Acudir.Challenge.API.Controllers
{
    // Las respuestas son sobre los mismos DTO no use capa presentators (requests/repsonses)
    // ni ningun formato de json, sólo el DTO

    [Route("api/people")]
    [ApiController]    
    public class PersonasController : ControllerBase
    {
        IPersonasService _personasService;

        public PersonasController(IPersonasService personasService)
        {
            _personasService = personasService;
        }

        [HttpGet]
        [SwaggerOperation("Devuelve la lista de personas")]
       
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<PersonaDTO>? personasDTO = await _personasService.GetAll();
                return Ok(personasDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("shuffle")]
        [SwaggerOperation("Devuelve una persona random")]

        public async Task<IActionResult> GetShuffle()
        {
            try
            {               
                PersonaDTO? personaDTO = await _personasService.GetShuffle();
                return Ok(personaDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation("Devuelve una persona por ID")]

        public async Task<IActionResult> Get([Required] int id)
        {
            try
            {
                PersonaDTO? personaDTO = await _personasService.Get(id);
                return Ok(personaDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [HttpDelete("{id:int}")]
        [SwaggerOperation("Borra una persona")]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                PersonaResultDTO? personaResultDTO = await _personasService.Delete(id);
                return Ok(personaResultDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
