using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Web.Services
{
    public interface IAlunoService
    { 
        Task<IEnumerable<AlunoDto>> GetAlunos();
    }
}
