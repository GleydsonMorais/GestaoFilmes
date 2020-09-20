using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFilmesAPI.Data.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public int GeneroId { get; set; }
        public string Sinopse { get; set; }
        public int? Ano { get; set; }

        public Genero Genero { get; set; }
    }
}
