using LibreriaOasis.Modelos;

namespace LibreriaOasis.Repositorios.Interfaces
{
    public interface IRepositorioComunas
    {
        Task<List<Comunas>> ObtenerTodos();
        Task<Comunas?> ObtenerPorId(int idComuna);

    }
}
