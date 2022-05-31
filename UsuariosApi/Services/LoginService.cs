using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result Login(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user => 
                    user.NormalizedUserName == request.UserName.ToUpper());

                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou");
        }

        public Result ResetaSenha(EfetuaResetRequest request)
        {
            IdentityUser<int> identity = ResulperaUsuarioporEmail(request.Email);

            IdentityResult resultadoIdentity = _signInManager
                .UserManager
                .ResetPasswordAsync(identity, request.Token, request.Password)
                .Result;

            if (resultadoIdentity.Succeeded) return Result.Ok()
                    .WithSuccess("Senha redefinida com sucesso!");

            return Result.Fail("Ouve um erro na operação");

        }

        private IdentityUser<int> ResulperaUsuarioporEmail(string email)
        {
            return _signInManager
                            .UserManager
                            .Users
                            .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

        public Result SolicitaResetSenha(SolicitaResetRequest request)
        {
            IdentityUser<int> identity = ResulperaUsuarioporEmail(request.Email);

            if (identity != null)
            {
                string codigoDeRucuperacao = _signInManager
                    .UserManager
                    .GeneratePasswordResetTokenAsync(identity).Result;

                return Result.Ok().WithSuccess(codigoDeRucuperacao);
            }

            return Result.Fail("Falha a solicitar reculperação.");
        }
    }
}
