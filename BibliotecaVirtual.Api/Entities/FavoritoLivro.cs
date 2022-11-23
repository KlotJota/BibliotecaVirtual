namespace BibliotecaVirtual.Api.Entities
{
    public class FavoritoLivro
    {
        public int Id { get; set; }

        public int FavoritoId { get; set; }
        public Favorito? Favoritos { get; set; }

        public int LivroId { get; set; }
        public Livro? Livros { get; set; }
    }
}
