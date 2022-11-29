using BibliotecaVirtual.Models.DTOs;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace BibliotecaVirtual.Web.Services
{
    public class LivroService : ILivroService
    {
        public HttpClient _httpClient;
        public ILogger<LivroService> _logger;

        public LivroService(HttpClient httpClient, ILogger<LivroService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<LivroDto>> GetLivros()
        {
            try
            {
                var livrosDto = await _httpClient.GetFromJsonAsync<IEnumerable<LivroDto>>("api/livros");

                return livrosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar os livros: api/livros");
                throw;
            }
        }

        public async Task<LivroDto> GetLivro(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/livros/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(LivroDto);
                    }
                    return await response.Content.ReadFromJsonAsync<LivroDto>();
                }
                else
                {
                    var mensagem = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro a obter produto pelo id= {id} - {mensagem}");
                    throw new Exception($"Status Code : {response.StatusCode} - {mensagem}");
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter produto pelo id={id}");
                throw;
            }
        }

        public async Task<IEnumerable<CategoriaDto>> GetCategorias()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Livros/GetCategorias");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CategoriaDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<CategoriaDto>>();

                }
                else
                {
                    var mensagem = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Status Code : {response.StatusCode} - {mensagem}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<LivroDto>> GetLivrosPorCategoria(int categoriaId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Livros/{categoriaId}/GetLivrosPorCategoria");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<LivroDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<LivroDto>>();
                }
                else
                {
                    var mensagem = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Status Code : {response.StatusCode} - {mensagem}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Add(AdicionaLivroDto adicionaLivroDto) 
        {
                var resposta = await _httpClient
                                .PostAsJsonAsync("api/livros",
                                adicionaLivroDto);

                return true;
        }

        public async Task<bool> Update(LivroDto livroDto)
        {
            try
            {
                var resposta = await _httpClient
                                .PutAsJsonAsync("api/livros",
                                livroDto);

                if (resposta.IsSuccessStatusCode) // status entre 200 a 299
                {
                    return true;
                }

                else
                {
                    // serializa o conteúdo HTTP como string
                    var mensagem = await resposta.Content.ReadAsStringAsync();
                    throw new Exception($"{resposta.StatusCode} Mensagem - {mensagem}");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var resposta =  _httpClient.DeleteAsync($"api/livros/{id}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
