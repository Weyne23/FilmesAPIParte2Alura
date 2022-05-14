using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UsuariosApi.Data.Request;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Login(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultadoIdentity.Result.Succeeded) 
                return Result.Ok();

            return Result.Fail("Login falhou");
        }
    }
}
