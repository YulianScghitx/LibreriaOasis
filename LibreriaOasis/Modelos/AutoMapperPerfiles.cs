using AutoMapper;
using LibreriaOasis.DTOs;
namespace LibreriaOasis.Modelos
{
    public class AutoMapperPerfiles : Profile
    {
        public AutoMapperPerfiles()
        {
            CreateMap<UsuariosEntradaDTO, Usuarios>();
            CreateMap<Usuarios, UsuariosSalidaDTO>();
            CreateMap<CategoriasEntradaDTO, Categorias>();
            CreateMap<Categorias, CategoriasSalidaDTO>();
            CreateMap<LibrosEntradaDTO, Libros>();
            CreateMap<Libros, LibrosSalidaDTO>();
        }
    }
}
