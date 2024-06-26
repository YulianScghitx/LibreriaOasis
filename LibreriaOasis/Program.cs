using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using LibreriaOasis.Repositorios;
using Microsoft.EntityFrameworkCore;
using LibreriaOasis.Rutas;

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
builder.Services.AddScoped<IRepositorioLibros, RepositorioLibros>();
builder.Services.AddScoped<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IRepositorioComunas, RepositorioComunas>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();
app.UseStaticFiles();
app.UseCors();
app.MapGroup("/libros").MapLibros();
app.MapGroup("/usuarios").MapUsuarios();
app.MapGroup("/categorias").MapCategorias();
app.MapGroup("/comunas").MapComunas();
app.Run();