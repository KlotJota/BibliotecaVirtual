using BibliotecaVirtual.Models.DTOs;
using System.Net.Http.Json;

namespace BibliotecaVirtual.Web.Services
{
    public class AlunoService: IAlunoService
    {
        public HttpClient _httpClient;
        public ILogger<AlunoService> _logger;

        public AlunoService(HttpClient httpClient, ILogger<AlunoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<AlunoDto>> GetAlunos()
        {
            try
            {
                var alunosDto = await _httpClient.GetFromJsonAsync<IEnumerable<AlunoDto>>("api/alunos");

                return alunosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar os alunos: api/alunos");
                throw;
            }
        }
    }
}
