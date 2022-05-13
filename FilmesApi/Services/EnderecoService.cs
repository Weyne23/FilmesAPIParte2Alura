using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class EnderecoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        internal IEnumerable<ReadEnderecoDto> RetornarEnderecos()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
        }

        public ReadEnderecoDto RetornasEnderecoPorId(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
                return null;

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public ReadEnderecoDto AdicionarEndereco(UpdateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
                return Result.Fail("Endereco não encontrado.");

            _mapper.Map(endereco, enderecoDto);
            _context.SaveChanges();
            return Result.Ok();
        }

        internal Result DeletarEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(enderecos => enderecos.Id == id);
            if (endereco == null)
                return Result.Fail("Endereco não encontrado.");

            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
