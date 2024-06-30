using LibreriaOasis.Modelos;

namespace LibreriaOasis.Repositorios.Interfaces
{
    public interface IRespositorioAuth
    {
        Task<bool> VerificarContrasena(string correo, string contrasenaIngresada);


    }
}
