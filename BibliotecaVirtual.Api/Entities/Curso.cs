using System.Collections.ObjectModel;

namespace BibliotecaVirtual.Api.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Turno { get; set; }

        public Collection<Aluno> Alunos { get; set; } = new Collection<Aluno>();
    }
}
