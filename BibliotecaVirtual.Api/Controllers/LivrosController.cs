using AutoMapper;
using BibliotecaVirtual.Api.Entities;
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
        private readonly IMapper _mapper;

        public LivrosController(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<LivroDto>> GetLivros()
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
                    var livrosDtos = livros.ConverterLivrosParaDto();
                    return Ok(livrosDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar o servidor interno");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetLivro(int id)
        {
            var livro = await _livroRepository.GetLivro(id);

            var livroRetorno = _mapper.Map<LivroDto>(livro);

            return livroRetorno != null
                                ? Ok(livroRetorno)
                                : BadRequest("Livro não encontrado");
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

        [HttpPost]
        public async Task<IActionResult> Post(AdicionaLivroDto livro)
        {
            if (livro == null) return BadRequest("Dados de livro inválidos");

            var livroAdiciona = _mapper.Map<Livro>(livro);

            _livroRepository.Add(livroAdiciona);

            return livroAdiciona.Id != null
                ? Ok("Livro adicionado com sucesso")
                : BadRequest("Erro ao adicionar o livro");
        }

        [HttpPut]
        public async Task<IActionResult> Put(LivroDto livro)
        {
            if (livro == null) return BadRequest("Livro não informado");
             
            var livroAtualizar = _mapper.Map<Livro>(livro);

            _livroRepository.Update(livroAtualizar);

            return livroAtualizar.Id != null
                ? Ok("Livro atualizado com sucesso")
                : BadRequest("Erro ao atualizar o livro");

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0) return BadRequest("Livro inválido");

            _livroRepository.Delete(Id);

            return Ok("Livro removido com sucesso");
        }
    }
}
