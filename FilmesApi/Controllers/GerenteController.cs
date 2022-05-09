using AutoMapper;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente(CreateGerenteDto dto)
        {
            var gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornarGerentePorId), new {Id = gerente.Id}, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RetornarGerentePorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                var gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return Ok(gerenteDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
