using AutoMapper;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Web;
using UsuariosApi.Data.Dtos.Usuario;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailServices;

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailServices)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailServices = emailServices;
        }

        public Result CadastrarUsuario(CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, dto.Password);
            var usuarioRoleResult = _userManager.AddToRoleAsync(usuarioIdentity, "regular").Result;

            if (resultadoIdentity.Result.Succeeded)
            {
                var codigo = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encondedCode = HttpUtility.UrlEncode(codigo);
                _emailServices.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de Ativação", usuarioIdentity.Id, encondedCode);
                return Result.Ok().WithSuccess(codigo);
            }

            return Result.Fail("Erro ao cadastrar usuario");
        }

        public Result AtivaContausuario(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(user => user.Id == request.UsuarioId);

            var identityResult = _userManager
                .ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao)
                .Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de usuário!");
        }
    }
}
