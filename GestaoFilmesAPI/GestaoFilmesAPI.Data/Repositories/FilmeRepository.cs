using GestaoFilmesAPI.Data.Contexts;
using GestaoFilmesAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFilmesAPI.Data.Repositories
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        Task<IList<Filme>> AllAsync();
        Task<Filme> GetByIdAsync(int filmeId);
    }

    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        private readonly GestaoFilmesAPIDbContext _dataContext;

        public FilmeRepository(GestaoFilmesAPIDbContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IList<Filme>> AllAsync() => await _dataContext.Filmes
            .Include(x => x.Genero)
            .ToListAsync();

        public async Task<Filme> GetByIdAsync(int filmeId) => await _dataContext.Filmes
            .Include(x => x.Genero)
            .SingleOrDefaultAsync(x => x.Id == filmeId);
    }
}
