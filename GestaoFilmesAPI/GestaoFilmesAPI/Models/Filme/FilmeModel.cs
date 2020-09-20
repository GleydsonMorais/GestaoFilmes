using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFilmesAPI.Models.Filme
{
    public class FilmeModel
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public int GeneroId { get; set; }
        public string Sinopse { get; set; }
        public int? Ano { get; set; }
    }
}
