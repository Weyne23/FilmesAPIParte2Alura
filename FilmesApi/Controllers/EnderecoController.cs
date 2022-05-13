using AutoMapper;
using FilmesApi.Services;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;
        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public IActionResult RetornasEnderecos()
        {
            IEnumerable<ReadEnderecoDto> readEnderecoDtos = _enderecoService.RetornarEnderecos();

            return Ok(readEnderecoDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RetornasEnderecoPorId(int id)
        {
            ReadEnderecoDto readEnderecoDtos = _enderecoService.RetornasEnderecoPorId(id);

            if (readEnderecoDtos == null) return NotFound();

            return Ok(readEnderecoDtos);
            
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody]UpdateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readEnderecoDtos = _enderecoService.AdicionarEndereco(enderecoDto);
            
            return CreatedAtAction(nameof(RetornasEnderecoPorId), new { Id = readEnderecoDtos.Id }, readEnderecoDtos);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody]UpdateEnderecoDto enderecoDto)
        {
            Result result = _enderecoService.AtualizarEndereco(id, enderecoDto);
            
            if(result.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result result = _enderecoService.DeletarEndereco(id);

            if (result.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
