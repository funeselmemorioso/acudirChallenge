using Acudir.Challenge.Mapping.Personas;
using Acudir.Challenge.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.RegisterAllDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(PersonasProfile));
builder.ConfigAllDbContexts();
builder.SwaggerConfig();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionsMiddleware>();
app.Run();
