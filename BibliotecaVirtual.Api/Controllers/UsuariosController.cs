using BibliotecaVirtual.Api.Mappings;
using BibliotecaVirtual.Api.Repositories;
using BibliotecaVirtual.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BibliotecaVirtual.Models.Login;
using BibliotecaVirtual.Api.Entities;

namespace BibliotecaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioRepository.GetUsuarios();
                if (usuarios == null)
                {
                    return NotFound();
                }
                else
                {
                    var usuariosDtos = usuarios.ConverterUsuariosParaDto();
                    return Ok(usuariosDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Erro ao acessar o servidor interno");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginDto login)
        {
            var usuario = await _usuarioRepository.CheckLogin(login.Email, login.Password);

            if (usuario != null)
            {
                return Ok(new LoginResponse() { IsAdmin = usuario.Status == 1 ? true : false, Id = usuario.Id });
            }
            else
            {
                return Unauthorized();
            }
        }

        /*[HttpPost]
        [Route("login")]
        public async Task<ActionResult> Id(LoginDto login)
        {
            var usuario = await _usuarioRepository.CheckId(login.Id);

            if (usuario != null)
            {
                return Ok(new LoginResponse() { Id = usuario.Id });
            }
            else
            {
                return Unauthorized();
            }
        }*/

    }
}
