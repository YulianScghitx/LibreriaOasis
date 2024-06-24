using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace LibreriaOasis.Repositorios
{
    public class RepositorioComunas : IRepositorioComunas
    {
        private readonly ConexionBDD contexto;
        public RepositorioComunas(ConexionBDD contexto)
        {
            this.contexto = contexto;
        }

        public async Task<List<Comunas>> ObtenerTodos()
        {
            return await contexto.Comunas.OrderBy( c => c.id).ToListAsync();
        }

        public ConexionBDD GetContexto()
        {
            return contexto;
        }

        public async Task<Comunas?> ObtenerPorId(int idComuna)
        {
            return await contexto.Comunas.Where(c => c.id == idComuna).FirstOrDefaultAsync();
        }
    }
}
