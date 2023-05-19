using gb_active_service_api.Configurations;
using gb_active_service_api.Data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ActivesDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("GbActiveServiceDb"));
    options.UseSqlServer("Data Source=192.168.122.129;Initial Catalog=GB_ACTIVE_SERVICE;User ID=sa;Password=$antos1612;TrustServerCertificate=true;");
});

builder.Services.ResolveDependencies();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
