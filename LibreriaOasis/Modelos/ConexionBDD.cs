using Microsoft.EntityFrameworkCore;
namespace LibreriaOasis.Modelos
{
    public class ConexionBDD : DbContext
    {
        public ConexionBDD(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
    }
}
