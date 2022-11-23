namespace BibliotecaVirtual.Api.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string ImagemUrl { get; set; }
        public string NomeLivro { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public int Quantidade { get; set; }
        public int QtdPaginas { get; set; }
        public string Editora { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categorias { get; set; }

        public List<LocacaoLivro>? LocacoesLivros{ get; set; }
        public List<FavoritoLivro>? FavoritosLivros { get; set; }
    }
}
