using API.Services;
using DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

RegisterServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CodeChallengeContext>(
    options => {
        var dbConnectionString = builder.Configuration.GetConnectionString("CodeChallengeConnection");
        options.UseSqlServer(dbConnectionString);
        }
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<CodeChallengeContext>();
    dataContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

void RegisterServices()
{
    builder.Services.AddSingleton<ISurfacesService, SurfacesService>();
    builder.Services.AddSingleton<ILostRobotsService, LostRobotsService>();
}