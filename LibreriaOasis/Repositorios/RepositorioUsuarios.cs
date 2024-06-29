using LibreriaOasis.Modelos;
using LibreriaOasis.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibreriaOasis.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly ConexionBDD contexto;
        public RepositorioUsuarios(ConexionBDD contexto)
        {
            this.contexto = contexto;
        }
        public async Task<List<Usuarios>> ObtenerTodos()
        {
            return await contexto.Usuarios.Where(x => x.activo).OrderBy(x => x.rut).ToListAsync();
        }
        public async Task<List<Usuarios>> ObtenerPorRut(string rut)
        {
            return await contexto.Usuarios.Where(x => x.rut.Contains(rut)).OrderBy(x => x.rut).ToListAsync();
        }
        public async Task<string> Crear(Usuarios usuarios)
        {
            contexto.Add(usuarios);
            await contexto.SaveChangesAsync();
            return usuarios.rut;
        }
        public async Task Desactivar(string rut)
        {
            var usuarios = await contexto.Usuarios.FirstOrDefaultAsync(x => x.rut == rut);
            if (usuarios != null)
            {
                usuarios.activo = false;
                await contexto.SaveChangesAsync();
            }
        }
        public async Task<bool> VerificarContrasena(string correo, string contrasenaIngresada)
        {
            var usuario = await contexto.Usuarios.FirstOrDefaultAsync(x => x.correo == correo);
            if (usuario == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(contrasenaIngresada, usuario.contrasena);
        }

        public async Task<Usuarios> ObtenerPorCorreo(string correo)
        {
            return await contexto.Usuarios.FirstOrDefaultAsync(x => x.correo == correo);
        }
    }
}
