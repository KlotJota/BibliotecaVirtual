using BibliotecaVirtual.Api.Entities;

namespace BibliotecaVirtual.Api.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();

        Task<Usuario> CheckLogin(string email, string password);

        /*Task<Usuario> CheckId(int id);*/
    }
}
