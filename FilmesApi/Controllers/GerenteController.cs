using AutoMapper;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using FilmesApi.Services;
using FilmesAPI.Data;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarGerente(CreateGerenteDto dto)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.AdicionarGerente(dto);
            
            return CreatedAtAction(nameof(RetornarGerentePorId), new {Id = readGerenteDto.Id}, readGerenteDto);
        }

        [HttpGet("{id}")]
        public IActionResult RetornarGerentePorId(int id)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.RetornarGerentePorId(id);
            
            if(readGerenteDto == null)
                return NotFound();

            return Ok(readGerenteDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result result = _gerenteService.DeletarGerente(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
