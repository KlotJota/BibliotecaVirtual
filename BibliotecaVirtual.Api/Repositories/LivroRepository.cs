using BibliotecaVirtual.Api.Context;
using BibliotecaVirtual.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Api.Repositories
{
    public class LivroRepository: ILivroRepository
    {
        private readonly BDBiblioteca _context;

        public void Add(Livro entity)
        {
            _context.Livros.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Livro entity)
        {
            _context.Update(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var entity = _context.Livros.Find(Id);
            _context.Livros.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public LivroRepository(BDBiblioteca context)
        {
            _context = context;
        }

        public async Task<Livro> GetLivro(int id)
        {
            var livro =     _context.Livros
                            .Include(g => g.Categorias)
                            .SingleOrDefault(g => g.Id == id);

            return livro;
        }

        public async Task<IEnumerable<Livro>> GetLivros()
        {
            var livros = await   _context.Livros
                                .Include(g => g.Categorias)
                                .ToListAsync();

            return livros;         
        }

        public async Task<IEnumerable<Livro>> GetLivrosPorCategoria(int id)
        {
            var livros = await  _context.Livros
                                .Include(g => g.Categorias)
                                .Where(g => g.CategoriaId == id).ToListAsync();

            return livros;
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return categorias;
        }
    }
}
