using LibreriaOasis.Modelos;

namespace LibreriaOasis.Repositorios.Interfaces
{
    public interface IRepositorioCategorias
    {
        Task<List<Categorias>> ObtenerTodos();
        Task<Categorias?> ObtenerPorId(int id);
        Task<int> Crear(Categorias categorias);
        Task<bool> Existe(int id);
        Task Actualizar(Categorias categorias);
        Task Borrar(int id);
    }
}
