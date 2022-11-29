using BibliotecaVirtual.Api.Entities;
using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Api.Repositories
{
    public interface IFavoritoRepository
    {
        Task<FavoritoLivro> AdicionaLivro(FavoritoAdicionaLivroDto favoritoAdicionaLivroDto);
        Task<FavoritoLivro> DeletaLivro(int id);
        Task<FavoritoLivro> GetLivro(int id);
        Task<IEnumerable<FavoritoLivro>> GetLivros(string alunoId);
    }
}
