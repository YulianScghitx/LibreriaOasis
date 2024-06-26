using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibreriaOasis.Repositorios
{
    public class RepositorioLibros : IRepositorioLibros
    {
        private readonly ConexionBDD contexto;
        public RepositorioLibros(ConexionBDD contexto)
        {
            this.contexto = contexto;
        }
        public async Task<List<Libros>> ObtenerTodos()
        {
            return await contexto.Libros.OrderBy(x => x.nombre).ToListAsync();
        }
        public async Task<Libros?> ObtenerPorId(int id)
        {
            return await contexto.Libros.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<int> Crear(Libros libros)
        {
            contexto.Add(libros);
            await contexto.SaveChangesAsync();
            return libros.id;
        }

        public async Task Actualizar(Libros libros)
        {
            contexto.Update(libros);
            await contexto.SaveChangesAsync();
        }

        public async Task Borrar(int id)
        {
            await contexto.Libros.Where(x => x.id == id).ExecuteDeleteAsync();
        }

        public async Task<bool> Existe(int id)
        {
            return await contexto.Libros.AnyAsync(x => x.id == id);
        }
    }
}
