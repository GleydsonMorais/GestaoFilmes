using GestaoFilmesAPI.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFilmesAPI.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync(T obj);
        void Update(T obj);
        void Delete(T obj);
        Task SaveAsync();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GestaoFilmesAPIDbContext _dataContext;

        public Repository(GestaoFilmesAPIDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task InsertAsync(T obj) => await _dataContext.AddAsync(obj);

        public void Update(T obj) => _dataContext.Update(obj);

        public void Delete(T obj) => _dataContext.Remove(obj);

        public async Task SaveAsync() => await _dataContext.SaveChangesAsync();
    }
}
