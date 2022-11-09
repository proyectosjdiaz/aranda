using Aranda.Negocio.Abstracciones;
using Aranda.Negocio.Reglas;
using Aranda.Persistencia.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ArandaDbContext>(options => { options.UseSqlServer(connectionString); });
builder.Services.AddScoped<IProductoReglas, ProductoReglas>();
builder.Services.AddScoped<ICategoriaReglas, CategoriaReglas>();

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
