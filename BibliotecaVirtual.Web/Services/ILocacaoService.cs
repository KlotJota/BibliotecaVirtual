using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Web.Services
{
    public interface ILocacaoService
    {
        Task<List<LocacaoLivroDto>> GetLivros(string alunoId);
        Task<LocacaoLivroDto> AdicionaLivro(LocacaoAdicionaLivroDto locacaoAdicionaLivroDto);
        Task<LocacaoLivroDto> DeletaLivro(int id);
    }
}
