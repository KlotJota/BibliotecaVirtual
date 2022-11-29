using BibliotecaVirtual.Models.DTOs;
using System.Net.Http.Json;
using System.Net;

namespace BibliotecaVirtual.Web.Services
{
    public class FavoritoService: IFavoritoService
    {
        private readonly HttpClient httpClient;
        public FavoritoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<FavoritoLivroDto> AdicionaLivro(FavoritoAdicionaLivroDto favoritoAdicionaLivroDto)
        {
            try
            {
                var resposta = await httpClient
                                .PostAsJsonAsync<FavoritoAdicionaLivroDto>("api/favorito",
                                favoritoAdicionaLivroDto);

                if (resposta.IsSuccessStatusCode) // status entre 200 a 299
                {
                    // caso não haja conteúdo
                    if (resposta.StatusCode == HttpStatusCode.NoContent)
                    {
                        // retorna um valor padrão/vazio
                        return default(FavoritoLivroDto);
                    }
                    // lê o conteúdo HTTP e retorna o valor da serialização do JSON para o obj Dto
                    return await resposta.Content.ReadFromJsonAsync<FavoritoLivroDto>();
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

        public async Task<FavoritoLivroDto> DeletaLivro(int id)
        {
            try
            {
                var resposta = await httpClient.DeleteAsync($"api/favorito/{id}");

                if (resposta.IsSuccessStatusCode)
                {
                    return await resposta.Content.ReadFromJsonAsync<FavoritoLivroDto>();
                }

                return default(FavoritoLivroDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FavoritoLivroDto>> GetLivros(string alunoId)
        {
            try
            {
                // request GET para a API Locacao 
                var resposta = await httpClient.GetAsync($"api/favorito/{alunoId}/GetLivros");

                if (resposta.IsSuccessStatusCode)
                {
                    // caso não haja conteúdo no carrinho, retorna uma lista vazia
                    if (resposta.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<FavoritoLivroDto>().ToList();
                    }
                    // caso não, retorna a lista com itens
                    return await resposta.Content.ReadFromJsonAsync<List<FavoritoLivroDto>>();
                }

                else
                {
                    var mensagem = await resposta.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {resposta.StatusCode} Mensagem: {mensagem}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
