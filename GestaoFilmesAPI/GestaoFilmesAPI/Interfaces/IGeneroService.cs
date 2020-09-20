using GestaoFilmesAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFilmesAPI.Interfaces
{
    public interface IGeneroService
    {
        Task<IList<Genero>> GetAllGeneroAsync();
    }
}
