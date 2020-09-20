using GestaoFilmesAPI.Data.Models;
using GestaoFilmesAPI.Data.Repositories;
using GestaoFilmesAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFilmesAPI.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public async Task<IList<Genero>> GetAllGeneroAsync() => await _generoRepository.AllAsync();
    }
}
