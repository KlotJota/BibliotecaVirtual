using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Web.Services
{
    public interface IFavoritoService
    {
        Task<List<FavoritoLivroDto>> GetLivros(string alunoId);
        Task<FavoritoLivroDto> AdicionaLivro(FavoritoAdicionaLivroDto favoritoAdicionaLivroDto);
        Task<FavoritoLivroDto> DeletaLivro(int id);
    }
}
