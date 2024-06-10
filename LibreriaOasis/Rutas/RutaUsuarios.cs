using AutoMapper;
using LibreriaOasis.DTOs;
using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using BCrypt.Net;

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
            grupo.MapPost("/verificar", VerificarContrasena);
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
        static async Task<Results<Ok, UnauthorizedHttpResult>> VerificarContrasena(LoginDTO verificarContrasenaDTO, IRepositorioUsuarios repositorio)
        {
            var esValido = await repositorio.VerificarContrasena(verificarContrasenaDTO.rut, verificarContrasenaDTO.contrasena);
            if (esValido)
            {
                return TypedResults.Ok();
            }
            else
            {
                return TypedResults.Unauthorized();
            }
        }
    }
}