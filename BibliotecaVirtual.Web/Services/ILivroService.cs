using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Web.Services
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroDto>> GetLivros();
        Task<LivroDto> GetLivro(int id);

        Task<IEnumerable<CategoriaDto>> GetCategorias();
        Task<IEnumerable<LivroDto>> GetLivrosPorCategoria(int categoriaId);

        Task<bool> Add(AdicionaLivroDto adicionaLivroDto);

        Task<bool> Update(LivroDto livroDto);

        public void Delete(int id);
    }
}
