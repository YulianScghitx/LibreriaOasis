using AutoMapper;
using LibreriaOasis.Modelos;
using LibreriaOasis.DTOs;
using LibreriaOasis.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaOasis.Rutas
{
    public static class RutaLibros
    {
        private static readonly string contenedor = "libros";
        public static RouteGroupBuilder MapLibros(this RouteGroupBuilder group)
        {
            group.MapGet("", ObtenerLibros);
            group.MapGet("/{id:int}", ObtenerLibrosPorId);
            group.MapPost("", CrearLibros).DisableAntiforgery();
            group.MapPut("/{id:int}", ActualizarLibros).DisableAntiforgery();
            group.MapDelete("/{id:int}", BorrarLibros);
            return group;
        }
        static async Task<Ok<List<LibrosSalidaDTO>>> ObtenerLibros(IRepositorioLibros repositorio, IMapper mapper)
        {
            var libros = await repositorio.ObtenerTodos();
            var librosDTO = mapper.Map<List<LibrosSalidaDTO>>(libros);
            return TypedResults.Ok(librosDTO);
        }
        static async Task<Results<Ok<LibrosSalidaDTO>, NotFound>> ObtenerLibrosPorId(int id, IRepositorioLibros repositorio, IMapper mapper)
        {
            var libros = await repositorio.ObtenerPorId(id);
            if (libros is null)
            {
                return TypedResults.NotFound();
            }
            var librosDTO = mapper.Map<LibrosSalidaDTO>(libros);
            return TypedResults.Ok(librosDTO);
        }

        static async Task<Created<LibrosSalidaDTO>> CrearLibros([FromForm] LibrosEntradaDTO librosEntradaDTO, IRepositorioLibros repositorio,
        IMapper mapper, IAlmacenadorArchivos almacenadorArchivos)
        {
            var libros = mapper.Map<Libros>(librosEntradaDTO);
            if (librosEntradaDTO.imagen is not null)
            {
                var url = await almacenadorArchivos.Almacenar(contenedor, librosEntradaDTO.imagen);
                libros.imagen = url;
            }
            var id = await repositorio.Crear(libros);
            var librosDTO = mapper.Map<LibrosSalidaDTO>(libros);
            return TypedResults.Created($"/{id}", librosDTO);
        }
        static async Task<Results<NoContent, NotFound>> ActualizarLibros([FromForm] LibrosEntradaDTO librosEntradaDTO, int id,
            IRepositorioLibros repositorio, IAlmacenadorArchivos almacenadorArchivos, IMapper mapper)
        {
            var librosDB = await repositorio.ObtenerPorId(id);
            if (librosDB is null)
            {
                return TypedResults.NotFound();
            }
            var librosActualizar = mapper.Map<Libros>(librosEntradaDTO);
            librosActualizar.id = id;
            librosActualizar.imagen = librosDB.imagen;
            if (librosEntradaDTO.imagen is not null)
            {
                var url = await almacenadorArchivos.Editar(librosActualizar.imagen, contenedor, librosEntradaDTO.imagen);
                librosActualizar.imagen = url;
            }
            await repositorio.Actualizar(librosActualizar);
            return TypedResults.NoContent();
        }
        static async Task<Results<NoContent, NotFound>> BorrarLibros(int id, IRepositorioLibros repositorio,
            IAlmacenadorArchivos almacenadorArchivos)
        {
            var librosDB = await repositorio.ObtenerPorId(id);
            if (librosDB is null)
            {
                return TypedResults.NotFound();
            }
            await repositorio.Borrar(id);
            await almacenadorArchivos.Borrar(librosDB.imagen, contenedor);
            return TypedResults.NoContent();
        }
    }
}