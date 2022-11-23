using BibliotecaVirtual.Api.Context;
using BibliotecaVirtual.Api.Entities;
using BibliotecaVirtual.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace BibliotecaVirtual.Api.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly BDBiblioteca _context;
        public LocacaoRepository(BDBiblioteca context)
        {
            _context = context;
        }

        private async Task<bool> LocacaoLivroJaExiste(int locacaoId, int livroId)
        {
            return await _context.LocacoesLivros.AnyAsync   (l => l.LocacaoId == locacaoId && 
                                                            l.LivroId == livroId);
        }

        public async Task<LocacaoLivro> AdicionaLivro(LocacaoAdicionaLivroDto locacaoAdicionaLivroDto)
        {
            if (await LocacaoLivroJaExiste  (locacaoAdicionaLivroDto.LocacaoId, 
                                            locacaoAdicionaLivroDto.LivroId) == false)
            {
                // verifica a existência do produto
                // cria um novo livro no carrinho
                var item = await (from livro in _context.Livros
                                   where livro.Id == locacaoAdicionaLivroDto.LivroId
                                   select new LocacaoLivro
                                   {
                                       LocacaoId = locacaoAdicionaLivroDto.LocacaoId,
                                       LivroId = livro.Id,
                                       Quantidade = locacaoAdicionaLivroDto.Quantidade
                                   }).SingleOrDefaultAsync();

                // caso o item exista, então será incluído na locação
                if (item is not null)
                {
                    var resultado = await _context.LocacoesLivros.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return resultado.Entity;
                }
            }
            return null;
        }

        public Task<LocacaoLivro> AtualizaQuantidade(int id, LocacaoAtualizaLivroDto locacaoAtualizaLivroDto)
        {
            throw new NotImplementedException();
        }

        public async Task<LocacaoLivro> DeletaLivro(int id)
        {
            var livro = await _context.LocacoesLivros.FindAsync(id);

            if (livro is not null)
            {
                _context.LocacoesLivros.Remove(livro);
                await _context.SaveChangesAsync();
            }

            return livro;
        }

        public async Task<LocacaoLivro> GetLivro(int id)
        {
            return await (from locacao in _context.Locacoes
                          join locacaoLivro in _context.LocacoesLivros
                          on locacao.Id equals locacaoLivro.LocacaoId
                          where locacaoLivro.Id == id
                          select new LocacaoLivro
                          {
                              Id = locacaoLivro.Id,
                              LivroId = locacaoLivro.LivroId,
                              LocacaoId = locacaoLivro.LocacaoId,
                              Quantidade = locacaoLivro.Quantidade
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<LocacaoLivro>> GetLivros(string alunoId)
        {
            return await (from locacao in _context.Locacoes
                          join locacaoLivro in _context.LocacoesLivros
                          on locacao.Id equals locacaoLivro.LocacaoId
                          where locacao.AlunoId == alunoId
                          select new LocacaoLivro
                          {
                              Id = locacaoLivro.Id,
                              LivroId = locacaoLivro.LivroId,
                              LocacaoId = locacaoLivro.LocacaoId,
                              Quantidade = locacaoLivro.Quantidade
                          }).ToListAsync();
        }
    }
}
