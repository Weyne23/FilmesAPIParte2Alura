using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos.Usuario;
using UsuariosApi.Data.Request;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroService _cadastroservice;

        public CadastroController(CadastroService cadastroservice)
        {
            _cadastroservice = cadastroservice;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto dto)
        {
            Result result = _cadastroservice.CadastrarUsuario(dto);

            if (result.IsFailed)
                return StatusCode(500);

            return Ok(result.Successes);
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContausuario([FromQuery] AtivaContaRequest request)
        {
            Result result = _cadastroservice.AtivaContausuario(request);

            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Successes);
        }
    }
}
