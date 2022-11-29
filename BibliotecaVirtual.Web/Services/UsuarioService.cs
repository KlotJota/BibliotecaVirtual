using BibliotecaVirtual.Models.DTOs;
using BibliotecaVirtual.Models.Login;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using BibliotecaVirtual.Web.Shared;
using BibliotecaVirtual.Web;

namespace BibliotecaVirtual.Web.Services
{
    public class UsuarioService : IUsuarioService
    {
        public HttpClient _httpClient;
        public ILogger<UsuarioService> _logger;
        public LoginContainer _loginContainer { get; set; }

        public UsuarioService(HttpClient httpClient, ILogger<UsuarioService> logger, LoginContainer loginContainer)
        {
            _httpClient = httpClient;
            _logger = logger;
            _loginContainer = loginContainer;
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuarios()
        {
            try
            {
                var usuariosDto = await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioDto>>("api/usuarios");

                return usuariosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar os usuários: api/usuarios");
                throw;
            }
        }

        public async Task<bool> CheckLogin(string email, string password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/usuarios/login", new LoginDto() { Email = email, Password = password });
                if (response.IsSuccessStatusCode)
                {
                    var loginresponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    _loginContainer.Logado = true;
                    _loginContainer.IsAdmin = loginresponse.IsAdmin;
                    _loginContainer.IdUser = loginresponse.Id;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar Pessoas: api/usuarios");
                throw;
            }
        }
    }
}
