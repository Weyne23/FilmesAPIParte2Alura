using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo de EnderecoId é obrigatório")]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "O campo de GerenteId é obrigatório")]
        public int GerenteId { get; set; }
    }
}
