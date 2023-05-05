using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Models;

namespace ProyectoTFG.Data
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuariosDbContext _context;

        public UsuarioService(UsuariosDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AgregarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);

            _context.Usuarios.Remove(user);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
        /*
         * Determina si el objeto Usuario ya existe en la base de datos
         * Si existe el Usuario usara el metodo UpdateUsuario
         * sino el metodo AgregarUsuario
         */
        public async Task<bool> SaveUsuario(Usuario usuario)
        {
            if (usuario.id > 0 )
                return await UpdateUsuario(usuario);
            else
                return await AgregarUsuario(usuario);
        }
    }
}
