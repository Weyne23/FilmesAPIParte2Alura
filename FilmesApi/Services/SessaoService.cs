using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using FilmesAPI.Data;
using System;

namespace FilmesApi.Services
{
    public class SessaoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto RecuperarSessaoPorId(int id)
        {
            var sessao = _context.Sessoes.Find(id);

            if (sessao == null)
                return null;

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto AdicionarSessao(CreateSessaoDto dto)
        {
            var sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }
    }
}
