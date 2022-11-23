using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace BibliotecaVirtual.Api.Entities
{
    public class LocacaoLivro
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public int LocacaoId { get; set; }
        public Locacao? Locacoes { get; set; }

        public int LivroId { get; set; }
        public Livro? Livros { get; set; }
    }
}
