using Acudir.Challenge.DA.DbContexts;
using Microsoft.EntityFrameworkCore;

public static class DbContextsConfiguration
{
    public static void ConfigAllDbContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AcudirDbContext>(
         options => options.UseSqlServer(
                 builder.Configuration.GetSection("ConnectionStrings")
                              .GetSection("AcudirDbContext")
                              .Value));
    }
}

