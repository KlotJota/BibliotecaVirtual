using BibliotecaVirtual.Api.Entities;

namespace BibliotecaVirtual.Api.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<IEnumerable<Aluno>> GetAlunosPorCurso(int id);
    }
}
