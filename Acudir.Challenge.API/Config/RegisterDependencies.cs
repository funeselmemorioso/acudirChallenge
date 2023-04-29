using Acudir.Challenge.DA.Repositories.Personas;
using Acudir.Challenge.Services.Personas;

public static class RegisterDependencies
{
    public static void RegisterAllDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPersonasRepository, PersonasRepository>();
        services.AddScoped<IPersonasService, PersonasService>();
    }
}

