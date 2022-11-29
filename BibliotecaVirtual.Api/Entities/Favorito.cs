namespace BibliotecaVirtual.Api.Entities
{
    public class Favorito
    {
        public int Id { get; set; }
        public string AlunoId { get; set; }

        public List<FavoritoLivro> FavoritoLivros { get; set; }
    }
}
