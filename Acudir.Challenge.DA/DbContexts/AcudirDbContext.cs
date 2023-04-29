using Acudir.Challenge.Models.Personas;
using Microsoft.EntityFrameworkCore;

namespace Acudir.Challenge.DA.DbContexts
{
    public class AcudirDbContext : DbContext
    {
        public virtual DbSet<Persona> Personas { get; set; }


        public AcudirDbContext(DbContextOptions<AcudirDbContext> options) : base(options)
        {
        }        
    }
}
