using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFilmesAPI.Data.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public IList<Filme> Filmes { get; set; }
    }
}
