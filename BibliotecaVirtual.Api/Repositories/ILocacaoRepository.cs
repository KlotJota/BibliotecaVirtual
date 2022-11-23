using BibliotecaVirtual.Api.Entities;
using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Api.Repositories
{
    public interface ILocacaoRepository
    {
        Task<LocacaoLivro> AdicionaLivro(LocacaoAdicionaLivroDto locacaoAdicionaLivroDto);
        Task<LocacaoLivro> DeletaLivro(int id);
        Task<LocacaoLivro> GetLivro(int id);
        Task<IEnumerable<LocacaoLivro>> GetLivros(string alunoId);
    }
}
