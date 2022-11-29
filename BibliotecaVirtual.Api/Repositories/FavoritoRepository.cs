using BibliotecaVirtual.Api.Context;
using BibliotecaVirtual.Api.Entities;
using BibliotecaVirtual.Models.DTOs;
using Microsoft.EntityFrameworkCore;


namespace BibliotecaVirtual.Api.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {
        private readonly BDBiblioteca _context;
        public FavoritoRepository (BDBiblioteca context)
        {
            _context = context;
        }

        private async Task<bool> FavoritoLivroJaExiste(int favoritoId, int livroId)
        {
            return await _context.FavoritoLivros.AnyAsync(l => l.FavoritoId == favoritoId &&
                                                            l.LivroId == livroId);
        }

        public async Task<FavoritoLivro> AdicionaLivro(FavoritoAdicionaLivroDto favoritoAdicionaLivroDto)
        {
            if (await FavoritoLivroJaExiste(favoritoAdicionaLivroDto.FavoritoId,
                                            favoritoAdicionaLivroDto.LivroId) == false)
            {
                // verifica a existência do produto
                // cria um novo livro nos favoritos
                var item = await(from livro in _context.Livros
                                 where livro.Id == favoritoAdicionaLivroDto.LivroId
                                 select new FavoritoLivro
                                 {
                                     FavoritoId = favoritoAdicionaLivroDto.FavoritoId,
                                     LivroId = livro.Id,
                                     Quantidade = favoritoAdicionaLivroDto.Quantidade
                                 }).SingleOrDefaultAsync();

                // caso o item exista, então será incluído em favoritos
                if (item is not null)
                {
                    var resultado = await _context.FavoritoLivros.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return resultado.Entity;
                }
            }
            return null;
        }

        public async Task<FavoritoLivro> DeletaLivro(int id)
        {
            var livro = await _context.FavoritoLivros.FindAsync(id);

            if (livro is not null)
            {
                _context.FavoritoLivros.Remove(livro);
                await _context.SaveChangesAsync();
            }

            return livro;
        }

        public async Task<IEnumerable<FavoritoLivro>> GetLivros(string alunoId)
        {
            return await(from favorito in _context.Favoritos
                         join favoritoLivro in _context.FavoritoLivros
                         on favorito.Id equals favoritoLivro.FavoritoId
                         where favorito.AlunoId == alunoId
                         select new FavoritoLivro
                         {
                             Id = favoritoLivro.Id,
                             LivroId = favoritoLivro.LivroId,
                             FavoritoId = favoritoLivro.FavoritoId,
                             Quantidade = favoritoLivro.Quantidade
                         }).ToListAsync();
        }

        public async Task<FavoritoLivro> GetLivro(int id)
        {
            return await(from favorito in _context.Favoritos
                         join favoritoLivro in _context.FavoritoLivros
                         on favorito.Id equals favoritoLivro.FavoritoId
                         where favoritoLivro.Id == id
                         select new FavoritoLivro
                         {
                             Id = favoritoLivro.Id,
                             LivroId = favoritoLivro.LivroId,
                             FavoritoId = favoritoLivro.FavoritoId,
                             Quantidade = favoritoLivro.Quantidade
                         }).SingleOrDefaultAsync();
        }
    }
}
