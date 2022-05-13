using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using FilmesApi.Services;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.RecuperarSessaoPorId(id);
            
            if(readSessaoDto == null)
                return NotFound();

            return Ok(readSessaoDto);
        }

        [HttpPost]
        public IActionResult AdicionarSessao(CreateSessaoDto dto)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.AdicionarSessao(dto);
            
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new {Id = readSessaoDto.Id}, readSessaoDto);
        }

    }
}
