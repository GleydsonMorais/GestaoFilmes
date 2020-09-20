using GestaoFilmesAPI.Data.Contexts;
using GestaoFilmesAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFilmesAPI.Data.Repositories
{
    public interface IGeneroRepository
    {
        Task<IList<Genero>> AllAsync();
        Task<Genero> GetByIdAsync(int generoId);
    }

    public class GeneroRepository : IGeneroRepository
    {
        private readonly GestaoFilmesAPIDbContext _dataContext;

        public GeneroRepository(GestaoFilmesAPIDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IList<Genero>> AllAsync() => await _dataContext.Generos.ToListAsync();

        public async Task<Genero> GetByIdAsync(int generoId) => await _dataContext.Generos
            .SingleOrDefaultAsync(x => x.Id == generoId);
    }
}
