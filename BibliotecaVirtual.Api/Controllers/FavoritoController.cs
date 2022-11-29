using BibliotecaVirtual.Api.Mappings;
using BibliotecaVirtual.Api.Repositories;
using BibliotecaVirtual.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritoController : ControllerBase
    {
        private readonly IFavoritoRepository favoritoRepo;
        private readonly ILivroRepository livroRepo;

        private ILogger<FavoritoController> logger;

        public FavoritoController(IFavoritoRepository favoritoRepository,
                                    ILivroRepository livroRepository,
                                    ILogger<FavoritoController> logger)
        {
            favoritoRepo = favoritoRepository;
            livroRepo = livroRepository;
            this.logger = logger;
        }

        [HttpGet]
        [Route("{alunoId}/GetLivros")]
        public async Task<ActionResult<IEnumerable<FavoritoLivroDto>>> GetLivros(string alunoId)
        {
            try
            {
                var favoritoLivros = await favoritoRepo.GetLivros(alunoId);
                if (favoritoLivros == null)
                {
                    return NoContent();
                }
                var livros = await this.livroRepo.GetLivros();
                if (livros == null)
                {
                    throw new Exception("Não existem livros...");
                }

                var favoritoLivrosDto = favoritoLivros.ConverterFavoritosLivrosParaDto(livros);
                return Ok(favoritoLivrosDto);
            }
            catch (Exception ex)
            {
                logger.LogError("Erro ao obter itens dos favoritos");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FavoritoLivroDto>> GetLivro(int id)
        {
            try
            {
                var favoritoLivro = await favoritoRepo.GetLivro(id);

                if (favoritoLivro == null)
                {
                    return NotFound($"Livro não encontrado");
                }

                var livro = await livroRepo.GetLivro(favoritoLivro.LivroId);

                if (livro == null)
                {
                    return NotFound($"Livro não existe na base de dados");
                }

                var favoritoLivroDto = favoritoLivro.ConverterFavoritoLivroParaDto(livro);

                return Ok(favoritoLivroDto);

            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter o livro {id} dos favoritos");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<FavoritoLivroDto>> PostLivro([FromBody]
        FavoritoAdicionaLivroDto favoritoAdicionaLivroDto)
        {
            try
            {
                var novoFavoritoLivro = await favoritoRepo.AdicionaLivro(favoritoAdicionaLivroDto);

                if (novoFavoritoLivro == null)
                {
                    return NoContent();
                }

                var livro = await livroRepo.GetLivro(novoFavoritoLivro.LivroId);

                if (livro == null)
                {
                    throw new Exception($"Livro não localizado (Id:({favoritoAdicionaLivroDto.LivroId})");
                }

                var novoFavoritoLivroDto = novoFavoritoLivro.ConverterFavoritoLivroParaDto(livro);

                return CreatedAtAction(nameof(GetLivro), new { id = novoFavoritoLivroDto.Id }, novoFavoritoLivroDto);
            }
            catch (Exception ex)
            {
                logger.LogError("Erro ao adicionar aos favoritos");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FavoritoLivroDto>> DeletaLivro(int id)
        {
            try
            {
                var favoritoLivro = await favoritoRepo.DeletaLivro(id);

                if (favoritoLivro == null)
                {
                    return NotFound();
                }

                var livro = await livroRepo.GetLivro(favoritoLivro.LivroId);

                if (livro is null)
                    return NotFound();

                var favoritoLivroDto = favoritoLivro.ConverterFavoritoLivroParaDto(livro);
                return Ok(favoritoLivroDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // *considerando um ambiente de desenvolvimento
            }
        }

    }
}

