using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UsuariosApi.Data.Dtos.Usuario;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastrarUsuario(CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, dto.Password);

            if (resultadoIdentity.Result.Succeeded)
                return Result.Ok();

            return Result.Fail("Erro ao cadastrar usuario");
        }
    }
}
