using System;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HoraEncerramentoSessao { get; set; }
    }
}
