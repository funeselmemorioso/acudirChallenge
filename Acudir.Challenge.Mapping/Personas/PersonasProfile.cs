using Acudir.Challenge.DTOs.Personas;
using Acudir.Challenge.Models.Personas;
using AutoMapper;

namespace Acudir.Challenge.Mapping.Personas
{
    public class PersonasProfile : Profile
    {
        public PersonasProfile()
        {
            CreateMap<PersonaDTO, Persona>()
                .ForMember(dest => dest.PersonaId, opt => opt.MapFrom(src => src.PersonaId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.Documento));

            CreateMap<Persona, PersonaDTO>()
                .ForMember(dest => dest.PersonaId, opt => opt.MapFrom(src => src.PersonaId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.Documento));
        }
    }
}

