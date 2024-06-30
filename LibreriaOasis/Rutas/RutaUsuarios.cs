using AutoMapper;
using LibreriaOasis.DTOs;
using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace LibreriaOasis.Rutas
{
    public static class RutaUsuarios
    {
        public static RouteGroupBuilder MapUsuarios(this RouteGroupBuilder grupo)
        {
            grupo.MapGet("", ObtenerUsuarios);
            grupo.MapGet("/{rut}", ObtenerUsuariosPorRut);
            grupo.MapPost("", CrearUsuarios);
            grupo.MapDelete("/{rut}", DesactivarUsuarios);
            grupo.MapPost("/Autorisa", Autorisa);
            return grupo;
        }
        static async Task<Ok<List<UsuariosSalidaDTO>>> ObtenerUsuarios(IRepositorioUsuarios repositorio, IMapper mapper)
        {
            var usuarios = await repositorio.ObtenerTodos();
            var usuariosDTO = mapper.Map<List<UsuariosSalidaDTO>>(usuarios);
            return TypedResults.Ok(usuariosDTO);
        }
        static async Task<Ok<List<UsuariosSalidaDTO>>> ObtenerUsuariosPorRut(string rut, IRepositorioUsuarios repositorio, IMapper mapper)
        {
            var usuarios = await repositorio.ObtenerPorRut(rut);
            var usuariosDTO = mapper.Map<List<UsuariosSalidaDTO>>(usuarios);
            return TypedResults.Ok(usuariosDTO);
        }
        static async Task<Created<UsuariosSalidaDTO>> CrearUsuarios(UsuariosEntradaDTO usuariosEntradaDTO, IRepositorioUsuarios repositorio, IMapper mapper)
        {
            var usuarios = mapper.Map<Usuarios>(usuariosEntradaDTO);
            usuarios.activo = true;
            usuarios.tipo_usuario = 2;
            usuarios.contrasena = BCrypt.Net.BCrypt.HashPassword(usuariosEntradaDTO.contrasena);
            var rut = await repositorio.Crear(usuarios);
            var usuariosDTO = mapper.Map<UsuariosSalidaDTO>(usuarios);
            return TypedResults.Created($"/", usuariosDTO);
        }
        [Authorize]
        static async Task<Results<NoContent, NotFound>> DesactivarUsuarios(string rut, IRepositorioUsuarios repositorio)
        {
            var usuariosDB = await repositorio.ObtenerPorRut(rut);
            if (usuariosDB is null)
            {
                return TypedResults.NotFound();
            }
            await repositorio.Desactivar(rut);
           return TypedResults.NoContent();
        }
        static async Task<Results<Ok<LoginDTO>, UnauthorizedHttpResult>> VerificarContrasena([FromBody]LoginDTO verificarContrasenaDTO, IRepositorioUsuarios repositorio)
        {
            bool esValido = await repositorio.VerificarContrasena(verificarContrasenaDTO.correo, verificarContrasenaDTO.contrasena);
            if (esValido)
            {

                Usuarios user = await repositorio.ObtenerPorCorreo(verificarContrasenaDTO.correo);

                LoginDTO sal = new LoginDTO()
                {
                    correo = user.correo,
                    contrasena = user.contrasena,
                    tipo_usuario = user.tipo_usuario.ToString(),
                };

                return TypedResults.Ok(sal);
            }
            else
            {
                return TypedResults.Unauthorized();
            }
        }

        static async Task<IResult> Autorisa([FromBody] LoginDTO user, IConfiguration config, IRepositorioUsuarios repositorio) 
        {
            bool esValido = await repositorio.VerificarContrasena(user.correo, user.contrasena);
            if (esValido)
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);
                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("correo", user.correo),
                new Claim("tipo_usuario", user.tipo_usuario.ToString())
            }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = config["Jwt:Issuer"],
                    Audience = config["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                string tokenString = tokenHandler.WriteToken(token);

                return Results.Ok(new { token = tokenString });
            }
            return Results.Unauthorized();

        }

    }
}