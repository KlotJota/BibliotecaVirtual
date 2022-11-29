using BibliotecaVirtual.Models.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace BibliotecaVirtual.Web.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly HttpClient httpClient;
        public LocacaoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<LocacaoLivroDto> AdicionaLivro(LocacaoAdicionaLivroDto locacaoAdicionaLivroDto)
        {
            try
            {
                var resposta = await httpClient
                                .PostAsJsonAsync<LocacaoAdicionaLivroDto>("api/locacao",
                                locacaoAdicionaLivroDto);

                if (resposta.IsSuccessStatusCode) // status entre 200 a 299
                {
                    // caso não haja conteúdo
                    if (resposta.StatusCode == HttpStatusCode.NoContent)
                    {
                        // retorna um valor padrão/vazio
                        return default(LocacaoLivroDto);
                    }
                    // lê o conteúdo HTTP e retorna o valor da serialização do JSON para o obj Dto
                    return await resposta.Content.ReadFromJsonAsync<LocacaoLivroDto>();
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

        public async Task<LocacaoLivroDto> DeletaLivro(int id)
        {
            try
            {
                var resposta = await httpClient.DeleteAsync($"api/locacao/{id}");

                if (resposta.IsSuccessStatusCode)
                {
                    return await resposta.Content.ReadFromJsonAsync<LocacaoLivroDto>();
                }

                return default(LocacaoLivroDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<LocacaoLivroDto>> GetLivros(string alunoId)
        {
            try
            {
                // request GET para a API Locacao 
                var resposta = await httpClient.GetAsync($"api/locacao/{alunoId}/GetLivros");

                if (resposta.IsSuccessStatusCode)
                {
                    // caso não haja conteúdo no carrinho, retorna uma lista vazia
                    if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<LocacaoLivroDto>().ToList();
                    }
                    // caso não, retorna a lista com itens
                    return await resposta.Content.ReadFromJsonAsync<List<LocacaoLivroDto>>();
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
