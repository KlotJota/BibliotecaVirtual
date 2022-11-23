using BibliotecaVirtual.Api.Mappings;
using BibliotecaVirtual.Api.Repositories;
using BibliotecaVirtual.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BibliotecaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoRepository locacaoRepo;
        private readonly ILivroRepository livroRepo;

        private ILogger<LocacaoController> logger;

        public LocacaoController(ILocacaoRepository locacaoRepository,
                                    ILivroRepository livroRepository,
                                    ILogger<LocacaoController> logger)
        {
            locacaoRepo = locacaoRepository;
            livroRepo = livroRepository;
            this.logger = logger;
        }

        [HttpGet]
        [Route("{alunoId}/GetLivros")]
        public async Task<ActionResult<IEnumerable<LocacaoLivroDto>>> GetLivros(string alunoId)
        {
            try
            {
                var locacaoLivros = await locacaoRepo.GetLivros(alunoId);
                if (locacaoLivros == null)
                {
                    return NoContent();
                }
                var livros = await this.livroRepo.GetLivros();
                if (livros == null)
                {
                    throw new Exception("Não existem livros...");
                }

                var locacaoLivrosDto = locacaoLivros.ConverterLocacoesLivrosParaDto(livros);
                return Ok(locacaoLivrosDto);
            }
            catch (Exception ex)
            {
                logger.LogError("Erro ao obter itens do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LocacaoLivroDto>> GetLivro(int id)
        {
            try
            {
                var locacaoLivro = await locacaoRepo.GetLivro(id);

                if (locacaoLivro == null)
                {
                    return NotFound($"Livro não encontrado");
                }

                var livro = await livroRepo.GetLivro(locacaoLivro.LivroId);

                if (livro == null)
                {
                    return NotFound($"Livro não existe na base de dados");
                }

                var locacaoLivroDto = locacaoLivro.ConverterLocacaoLivroParaDto(livro);

                return Ok(locacaoLivroDto);

            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter o livro {id} da locação");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<LocacaoLivroDto>> PostLivro([FromBody]
        LocacaoAdicionaLivroDto locacaoAdicionaLivroDto)
        {
            try
            {
                var novoLocacaoLivro = await locacaoRepo.AdicionaLivro(locacaoAdicionaLivroDto);

                if (novoLocacaoLivro == null)
                {
                    return NoContent();
                }

                var livro = await livroRepo.GetLivro(novoLocacaoLivro.LivroId);

                if (livro == null)
                {
                    throw new Exception($"Livro não localizado (Id:({locacaoAdicionaLivroDto.LivroId})");
                }

                var novoLocacaoLivroDto = novoLocacaoLivro.ConverterLocacaoLivroParaDto(livro);

                return CreatedAtAction(nameof(GetLivro), new { id = novoLocacaoLivroDto.Id }, novoLocacaoLivroDto);
            }
            catch (Exception ex)
            {
                logger.LogError("Erro ao criar um novo item em seu carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<LocacaoLivroDto>> DeletaLivro(int id)
        {
            try
            {
                var locacaoLivro = await locacaoRepo.DeletaLivro(id);

                if (locacaoLivro == null)
                {
                    return NotFound();
                }

                var livro = await livroRepo.GetLivro(locacaoLivro.LivroId);

                if (livro is null)
                    return NotFound();

                var locacaoLivroDto = locacaoLivro.ConverterLocacaoLivroParaDto(livro);
                return Ok(locacaoLivroDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // *considerando um ambiente de desenvolvimento
            }
        }

    }
}

