using BibliotecaVirtual.Api.Entities;

namespace BibliotecaVirtual.Api.Repositories
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetLivros();
        Task<Livro> GetLivro(int id);

        Task<IEnumerable<Livro>> GetLivrosPorCategoria(int id);
        Task<IEnumerable<Categoria>> GetCategorias();

    }

}


/* Repository pattern: uma coleção de objetos de domínio em memória, permite realizar o isolamento
entre a camada de acesso a dados e sua camada de apresentação

- centraliza o codigo comum para acesso a dados, facilitando manutençao e evitando duplicidade;
- facilita a implementação de testes unitarios
- reduz acoplamento entre os componentes de acesso a dados e o modelo de domínio
- permite a troca do BD utilizado sem afetar o sistema */
