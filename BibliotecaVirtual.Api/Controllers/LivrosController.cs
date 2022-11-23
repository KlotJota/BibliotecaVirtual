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
    public class LivrosController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDto>>> GetLivros()
        {
            try
            {
                var livros = await _livroRepository.GetLivros();

                if (livros == null)
                {
                    return NotFound();
                }
                else
                {
                    var livroDtos = livros.ConverterLivrosParaDto();
                    return Ok(livroDtos);
                }
            }
            catch(Exception)
            {
                return  StatusCode(StatusCodes.Status500InternalServerError,
                        "Erro ao acessar o servidor interno");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<LivroDto>>> GetLivro(int id)
        {
            try
            {
                var livro = await _livroRepository.GetLivro(id);
                if (livro == null)
                {
                    return NotFound("Erro ao localizar o livro informado");
                }
                else
                {
                    var livroDto = livro.ConverterLivroParaDto();
                    return Ok(livroDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Erro ao acessar o servidor interno");
            }
        }

        [HttpGet]
        [Route("{categoriaId}/GetLivrosPorCategoria")]
        public async Task<ActionResult<IEnumerable<LivroDto>>> 
                        GetLivrosPorCategoria(int categoriaId)
        {
            try
            {
                var livros = await _livroRepository.GetLivrosPorCategoria(categoriaId);
                var livrosDto = livros.ConverterLivrosParaDto();
                return Ok(livrosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Erro ao acessar o servidor interno");
            }
        }

        [HttpGet]
        [Route("GetCategorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategorias()
        {
            try
            {
                var categorias = await _livroRepository.GetCategorias();
                var categoriasDto = categorias.ConverterCategoriasParaDto();
                return Ok(categoriasDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Erro ao acessar o servidor interno");
            }
        }
    }
}
