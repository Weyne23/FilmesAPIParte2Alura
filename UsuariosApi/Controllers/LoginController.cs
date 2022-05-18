﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Request;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            Result result = _loginService.Login(request);

            if(result.IsFailed) return Unauthorized(result.Errors);

            return Ok(result.Successes);
        }
    }
}
