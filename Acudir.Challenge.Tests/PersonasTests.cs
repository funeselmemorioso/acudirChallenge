using Acudir.Challenge.DA.DbContexts;
using Acudir.Challenge.DA.Repositories.Personas;
using Acudir.Challenge.DTOs.Personas;
using Acudir.Challenge.Mapping.Personas;
using Acudir.Challenge.Services.Personas;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Acudir.Challenge.Tests
{
    public class Tests
    {
        AcudirDbContext context;
        IConfiguration configuration;
        IMapper _mapper;

        [SetUp]
        public void Setup()
        {           
            var options = new DbContextOptionsBuilder<AcudirDbContext>()
            .UseInMemoryDatabase(databaseName: "db")
            .Options;

            context = new AcudirDbContext(options);
            Random r = new Random();
            context.Personas.RemoveRange(context.Personas);
            context.SaveChanges();
            context.Personas.Add(new Models.Personas.Persona {PersonaId=r.Next(10,1000), Activa = true, Nombre = "hola", Apellido = "mundo", Documento = "123456" });
            context.Personas.Add(new Models.Personas.Persona { PersonaId = 1, Activa = true, Nombre = "ffsdsf", Apellido = "dssdsd", Documento = "33333" });
            context.Personas.Add(new Models.Personas.Persona { PersonaId = 2, Activa = true, Nombre = "ffsdsf", Apellido = "dssdsd", Documento = "33333" });
            context.SaveChanges();


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PersonasProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        [Test]
        public async Task GetAll()
        {
            IPersonasRepository repo = new PersonasRepository(context);
            IPersonasService servicio = new PersonasService(_mapper, context);

            List<PersonaDTO>? p = await servicio.GetAll();

            context.Dispose();


            if (p.Count > 0) { Assert.Pass(); }
            Assert.Fail();
        }

        [Test]
        public async Task GetShuffle()
        {
            IPersonasRepository repo = new PersonasRepository(context);
            IPersonasService servicio = new PersonasService(_mapper, context);

            PersonaDTO? p = await servicio.GetShuffle();

            context.Dispose();

            if (p is not null) { Assert.Pass(); }
            Assert.Fail();
        }

        [Test]
        public async Task GetById()
        {
            IPersonasRepository repo = new PersonasRepository(context);
            IPersonasService servicio = new PersonasService(_mapper, context);

            PersonaDTO? p = await servicio.Get(1);

            context.Dispose();

            if (p is not null) { Assert.Pass(); }
            Assert.Fail();
        }

        [Test]
        public async Task Delete()
        {
            IPersonasRepository repo = new PersonasRepository(context);
            IPersonasService servicio = new PersonasService(_mapper, context);

            PersonaResultDTO? p = await servicio.Delete(2);

            PersonaDTO? pp = await servicio.Get(2);

            context.Dispose();

            if (pp is null) { Assert.Pass(); }
            Assert.Fail();
        }
    }
}