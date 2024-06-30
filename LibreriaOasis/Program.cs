using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using LibreriaOasis.Repositorios;
using Microsoft.EntityFrameworkCore;
using LibreriaOasis.Rutas;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//SERVICIOS
builder.Services.AddDbContext<ConexionBDD>(opciones => opciones.UseSqlServer("name=DefaultConnection"));

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy => policy.RequireRole("1"));
        options.AddPolicy("UserOrAdmin", policy => policy.RequireRole("1", "2"));
        // Add more policies as needed
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseCors();
app.MapGroup("/libros").MapLibros();
app.MapGroup("/usuarios").MapUsuarios();
app.MapGroup("/categorias").MapCategorias();
app.MapGroup("/comunas").MapComunas();
app.Run();