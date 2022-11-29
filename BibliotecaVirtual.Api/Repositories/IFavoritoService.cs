using BibliotecaVirtual.Api.Entities;
using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Api.Repositories
{
    public interface IFavoritoService
    {
        Task<FavoritoLivro> AdicionaLivro(FavoritoAdicionaLivroDto favoritoAdicionaLivroDto);
        Task<FavoritoLivro> DeletaLivro(int id);
        Task<IEnumerable<FavoritoLivro>> GetLivros(string alunoId);
    }
}
