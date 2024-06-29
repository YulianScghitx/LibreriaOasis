using AutoMapper;
using LibreriaOasis.DTOs;
using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaOasis.Rutas
{
    public static class RutaComunas
    {
        public static RouteGroupBuilder MapComunas(this RouteGroupBuilder grupo)
        {
            grupo.MapGet("", ObtenerComunas);
            grupo.MapGet("/{id}", ObtenerComunaPorId);

            return grupo;
        }
        static async Task<Ok<List<ComunasDTO>>> ObtenerComunas( [FromServices] IRepositorioComunas repositorio, 
                                                                [FromServices] IMapper mapper)
        {
            List<Comunas> comunas = await repositorio.ObtenerTodos();
            List<ComunasDTO> comunasDTO = mapper.Map<List<ComunasDTO>>(comunas);
            return TypedResults.Ok(comunasDTO);
        }

        static async Task<Ok<ComunasDTO>> ObtenerComunaPorId([FromRoute] int id, 
                                                            [FromServices] IRepositorioComunas repositorio, 
                                                            [FromServices] IMapper mapper ) 
        {
            Comunas? comuna = await repositorio.ObtenerPorId(id);            
            ComunasDTO comunasDTO = (comuna is null)? new ComunasDTO() { id = 0 , nombre= string.Empty, region = 0 } : mapper.Map<ComunasDTO>(comuna);
            return TypedResults.Ok(comunasDTO);        
        }
    }
}
