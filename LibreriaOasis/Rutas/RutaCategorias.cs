using AutoMapper;
using LibreriaOasis.DTOs;
using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaOasis.Rutas
{
    public static class RutaCategorias
    {
        public static RouteGroupBuilder MapCategorias(this RouteGroupBuilder group)
        {
            group.MapGet("", ObtenerCategorias);
            group.MapGet("/{id:int}", ObtenerCategoriasPorId);
            group.MapPost("", CrearCategorias);
            group.MapPut("/{id:int}", ActualizarCategorias);
            group.MapDelete("/{id:int}", BorrarCategorias);
            return group;
        }
        static async Task<Ok<List<CategoriasSalidaDTO>>> ObtenerCategorias(IRepositorioCategorias repositorio, IMapper mapper)
        {
            var categorias = await repositorio.ObtenerTodos();
            var categoriasDTO = mapper.Map<List<CategoriasSalidaDTO>>(categorias);
            return TypedResults.Ok(categoriasDTO);
        }
        static async Task<Results<Ok<CategoriasSalidaDTO>, NotFound>> ObtenerCategoriasPorId(int id, IRepositorioCategorias repositorio, IMapper mapper)
        {
            var categorias = await repositorio.ObtenerPorId(id);
            if (categorias is null)
            {
                return TypedResults.NotFound();
            }
            var categoriasDTO = mapper.Map<CategoriasSalidaDTO>(categorias);
            return TypedResults.Ok(categoriasDTO);
        }

        static async Task<Created<CategoriasSalidaDTO>> CrearCategorias(CategoriasEntradaDTO categoriasEntradaDTO, IRepositorioCategorias repositorio, IMapper mapper)
        {
            var categorias = mapper.Map<Categorias>(categoriasEntradaDTO);
            var id = await repositorio.Crear(categorias);
            var categoriasDTO = mapper.Map<CategoriasSalidaDTO>(categorias);
            return TypedResults.Created($"/{id}", categoriasDTO);
        }
        static async Task<Results<NoContent, NotFound>> ActualizarCategorias(CategoriasEntradaDTO categoriasEntradaDTO, int id,
            IRepositorioCategorias repositorio, IMapper mapper)
        {
            var categoriasDB = await repositorio.ObtenerPorId(id);
            if (categoriasDB is null)
            {
                return TypedResults.NotFound();
            }
            var categoriasActualizar = mapper.Map<Categorias>(categoriasEntradaDTO);
            categoriasActualizar.id = id;
            await repositorio.Actualizar(categoriasActualizar);
            return TypedResults.NoContent();
        }
        static async Task<Results<NoContent, NotFound>> BorrarCategorias(int id, IRepositorioCategorias repositorio)
        {
            var categoriasDB = await repositorio.ObtenerPorId(id);
            if (categoriasDB is null)
            {
                return TypedResults.NotFound();
            }
            await repositorio.Borrar(id);
            return TypedResults.NoContent();
        }
    }
}