using BibliotecaVirtual.Api.Context;
using BibliotecaVirtual.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Api.Repositories
{
    public class AlunoRepository: IAlunoRepository
    {
        private readonly BDBiblioteca _context;

        public AlunoRepository(BDBiblioteca context)
        {
            _context = context;
        }

        public async Task<Aluno> GetAluno(int id)
        {
            var aluno =      _context.Alunos
                            .Include(g => g.Cursos)
                            .SingleOrDefault(g => g.Id == id);

            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            var alunos = await _context.Alunos
                                .Include(g => g.Cursos)
                                .ToListAsync();

            return alunos;
        }

        public async Task<IEnumerable<Aluno>> GetAlunosPorCurso(int id)
        {
            var alunos = await  _context.Alunos
                                .Include(g => g.Cursos)
                                .Where(g => g.CursoId == id).ToListAsync();

            return alunos;
        }
    }
}
