using gb_active_service_api.Configurations;
using gb_active_service_api.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ActivesDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("GbActiveServiceDb"));
    //options.UseSqlServer("Data Source=192.168.122.129;Initial Catalog=GB_ACTIVE_SERVICE;User ID=sa;Password=$antos1612;TrustServerCertificate=true;");
    options.UseNpgsql("User ID=postgres;Password=pucminas456;Host=servweb.vps.webdock.cloud;Port=5432;Database=GB_ACTIVE_SERVICE;Pooling=true;");
});

builder.Services.ResolveDependencies();

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthCheck", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthCheck v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/health");

app.Run();
