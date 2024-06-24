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
            CreateMap<Comunas, ComunasDTO>();
        }
    }
}
