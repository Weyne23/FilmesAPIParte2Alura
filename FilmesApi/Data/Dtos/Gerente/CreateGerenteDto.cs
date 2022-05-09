using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.Gerente
{
    public class CreateGerenteDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
