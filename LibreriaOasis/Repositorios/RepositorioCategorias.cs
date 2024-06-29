using LibreriaOasis.Modelos;
using Microsoft.EntityFrameworkCore;
using LibreriaOasis.Repositorios.Interfaces;


namespace LibreriaOasis.Repositorios
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly ConexionBDD contexto;
        public RepositorioCategorias(ConexionBDD contexto)
        {
            this.contexto = contexto;
        }
        public async Task<List<Categorias>> ObtenerTodos()
        {
            return await contexto.Categorias.OrderBy(x => x.id).ToListAsync();
        }
        public async Task<Categorias?> ObtenerPorId(int id)
        {
            return await contexto.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<int> Crear(Categorias categorias)
        {
            contexto.Add(categorias);
            await contexto.SaveChangesAsync();
            return categorias.id;
        }

        public async Task Actualizar(Categorias categorias)
        {
            contexto.Update(categorias);
            await contexto.SaveChangesAsync();
        }

        public async Task Borrar(int id)
        {
            await contexto.Categorias.Where(x => x.id == id).ExecuteDeleteAsync();
        }

        public async Task<bool> Existe(int id)
        {
            return await contexto.Categorias.AnyAsync(x => x.id == id);
        }
    }
}
