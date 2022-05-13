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
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public IEnumerable<ReadFilmeDto> RecuperarFilme(int? classificacaoEtaria)
        {
            IEnumerable<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes;
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria);
            }

            if (filmes != null)
            {
                IEnumerable<ReadFilmeDto> readDto = _mapper.Map<IEnumerable<ReadFilmeDto>>(filmes);
                return readDto;
            }

            return null;
        }

        internal ReadFilmeDto RecuperaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return filmeDto;
            }

            return null;
        }

        public Result DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return Result.Fail("Filme não encontrado.");

            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result AtualizarFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return Result.Fail("Filme não encontrado.");

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
