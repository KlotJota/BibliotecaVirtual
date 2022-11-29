using BibliotecaVirtual.Api.Entities;
using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Api.Repositories
{
    public class FavoritoService : IFavoritoService
    {
        public Task<FavoritoLivro> AdicionaLivro(FavoritoAdicionaLivroDto favoritoAdicionaLivroDto)
        {
            throw new NotImplementedException();
        }

        public Task<FavoritoLivro> DeletaLivro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FavoritoLivro>> GetLivros(string alunoId)
        {
            throw new NotImplementedException();
        }
    }
}
