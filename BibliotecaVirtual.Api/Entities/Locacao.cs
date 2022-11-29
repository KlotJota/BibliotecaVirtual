namespace BibliotecaVirtual.Api.Entities
{
    public class Locacao
    {
        public int Id { get; set; }
        public string AlunoId { get; set; }

        public List<LocacaoLivro> LocacaoLivros { get; set; }
    }
}
