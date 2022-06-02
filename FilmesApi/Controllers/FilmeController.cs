using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeServices;
        public FilmeController(FilmeService filmeServices)
        {
            _filmeServices  = filmeServices;
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var readFilmeDto = _filmeServices.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readFilmeDto.Id }, readFilmeDto);
        }

        [HttpGet()]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var readDto = _filmeServices.RecuperarFilme(classificacaoEtaria);

            if(readDto != null) return Ok(readDto);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var filmeDto = _filmeServices.RecuperaFilmePorId(id);

            if (filmeDto != null) return Ok(filmeDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var result = _filmeServices.AtualizarFilme(id, filmeDto);

            if(result.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var result = _filmeServices.DeletarFilme(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}