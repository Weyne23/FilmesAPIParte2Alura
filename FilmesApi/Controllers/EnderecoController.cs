using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
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
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Endereco> RetornasEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RetornasEnderecoPorId(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
                return NotFound();

            return Ok(_mapper.Map<ReadEnderecoDto>(endereco));
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody]UpdateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornasEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody]UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
                return NotFound();

            _mapper.Map(endereco, enderecoDto);
            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(enderecos => enderecos.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
