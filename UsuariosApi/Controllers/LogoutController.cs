using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DesclogarUsuario()
        {
            Result result = _logoutService.DeslogaUsuario();

            if(result.IsFailed) return Unauthorized(result.Errors);

            return Ok(result.Successes);
        }
    }
}
