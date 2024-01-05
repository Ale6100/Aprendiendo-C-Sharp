using DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BarContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BarConnection")); // Asociamos la base de datos con el proyecto
});

var app = builder.Build();

/*
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BarContext>();
    context.Database.Migrate(); // Hace que se cree la base de datos y las tablas especificadas en BarContext. También aplica los cambios en caso de que se hayan hecho
}
*/

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
