using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Web.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetUsuarios();
        Task<bool> CheckLogin(string email, string password);
    }
}
