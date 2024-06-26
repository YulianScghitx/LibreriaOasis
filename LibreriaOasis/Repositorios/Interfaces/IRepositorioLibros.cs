using LibreriaOasis.Modelos;

namespace LibreriaOasis.Repositorios.Interfaces
{
    public interface IRepositorioLibros
    {
        Task<List<Libros>> ObtenerTodos();
        Task<Libros?> ObtenerPorId(int id);
        Task<int> Crear(Libros libros);
        Task<bool> Existe(int id);
        Task Actualizar(Libros libros);
        Task Borrar(int id);
    }
}
