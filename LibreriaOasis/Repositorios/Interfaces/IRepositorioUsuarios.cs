using LibreriaOasis.Modelos;

namespace LibreriaOasis.Repositorios.Interfaces
{
    public interface IRepositorioUsuarios
    {
        Task<List<Usuarios>> ObtenerTodos();
        Task<List<Usuarios>> ObtenerPorRut(string rut);
        Task<Usuarios> ObtenerPorCorreo(string correo);
        Task<string> Crear(Usuarios usuarios);
        Task Desactivar(string rut);
        Task<bool> VerificarContrasena(string correo, string contrasenaIngresada);
    }
}
