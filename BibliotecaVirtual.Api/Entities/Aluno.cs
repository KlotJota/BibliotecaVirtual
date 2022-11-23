namespace BibliotecaVirtual.Api.Entities
{
    public class Aluno : Usuario
    {
        public string Ra { get; set; }

        public int CursoId { get; set; }
        public Curso? Cursos { get; set; }  // Agregação

        public Locacao? Locacoes { get; set; }
        public Favorito? Favoritos { get; set; }
    }
}
