using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao(CreateSessaoDto dto)
        {
            var sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarSessoesPorId), new {Id = sessao.Id}, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessoesPorId(int id)
        {
            var sessao = _context.Sessoes.Find(id);

            if (sessao == null)
                return NotFound();

            return Ok(_mapper.Map<ReadSessaoDto>(sessao));
        }
    }
}
