using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using LibreriaOasis.Repositorios;
using Microsoft.EntityFrameworkCore;
using LibreriaOasis.Rutas;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
//SERVICIOS
builder.Services.AddDbContext<ConexionBDD>(opciones => opciones.UseSqlServer("name=DefaultConnection"));
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(configuracion =>
    {
        configuracion.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddScoped<IRepositorioCategorias, RepositorioCategorias>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();
app.UseCors();
app.MapGroup("/usuarios").MapUsuarios();
app.MapGroup("/categorias").MapCategorias();
app.Run();