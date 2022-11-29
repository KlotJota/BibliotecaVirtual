using BibliotecaVirtual.Api.Context;
using BibliotecaVirtual.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Api.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly BDBiblioteca _context;

        public UsuarioRepository(BDBiblioteca context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            return usuarios;
        }

        public async Task<Usuario> CheckLogin(string email, string password)
        {
            var usuario = await _context.Usuarios.Where(x => x.Email == email && x.Senha == password).SingleOrDefaultAsync();
            return usuario;
        }

        /*public async Task<Usuario> CheckId(int id)
        {
            var usuario = await _context.Usuarios.Where(x => x.Id == id).SingleOrDefaultAsync();
            return usuario;
        }*/
    }
}
