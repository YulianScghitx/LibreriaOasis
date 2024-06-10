using LibreriaOasis.Modelos;

namespace LibreriaOasis.Repositorios.Interfaces
{
    public interface IRepositorioUsuarios
    {
        Task<List<Usuarios>> ObtenerTodos();
        Task<List<Usuarios>> ObtenerPorRut(string rut);
        Task<string> Crear(Usuarios usuarios);
        Task Desactivar(string rut);
        Task<bool> VerificarContrasena(string rut, string contrasenaIngresada);
    }
}
