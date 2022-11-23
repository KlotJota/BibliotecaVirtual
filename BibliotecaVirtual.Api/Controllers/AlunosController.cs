using BibliotecaVirtual.Api.Mappings;
using BibliotecaVirtual.Api.Repositories;
using BibliotecaVirtual.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunosController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDto>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoRepository.GetAlunos();
                if (alunos == null)
                {
                    return NotFound();
                }
                else
                {
                    var alunosDtos = alunos.ConverterAlunosParaDto();
                    return Ok(alunosDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Erro ao acessar o servidor interno");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<AlunoDto>>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoRepository.GetAluno(id);
                if (aluno == null)
                {
                    return NotFound("Erro ao localizar o aluno em questão");
                }
                else
                {
                    var alunoDto = aluno.ConverterAlunoParaDto();
                    return Ok(alunoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Erro ao acessar o servidor interno");
            }
        }

        [HttpGet]
        [Route("GetAlunosPorCurso/{cursoId}")]
        public async Task<ActionResult<IEnumerable<AlunoDto>>> GetAlunosPorCurso(int cursoId)
        {
            try
            {
                var alunos = await _alunoRepository.GetAlunosPorCurso(cursoId);
                var alunosDto = alunos.ConverterAlunosParaDto();
                return Ok(alunosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Erro ao acessar o servidor interno");
            }
        } 
    }
}

    

