using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();
var app = builder.Build();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();
        await DbInitializer.SeedData(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An Error Occurred during migration");
    }
}

// Map HTTP endpoints
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
  .WithOrigins("http://localhost:3000","https://localhost:3000"));
  
app.MapControllers();

app.Run();

