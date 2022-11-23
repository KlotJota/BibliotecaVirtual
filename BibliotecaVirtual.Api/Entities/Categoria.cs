using System.Collections.ObjectModel;

namespace BibliotecaVirtual.Api.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Collection<Livro> Livros { get; set; } = new Collection<Livro>();
    }
}
