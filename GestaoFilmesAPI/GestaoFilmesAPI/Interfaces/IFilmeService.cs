using GestaoFilmesAPI.Data.Helpers;
using GestaoFilmesAPI.Data.Models;
using GestaoFilmesAPI.Models.Filme;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFilmesAPI.Interfaces
{
    public interface IFilmeService
    {
        Task<IList<Filme>> GetAllFilmeAsync();
        Task<Filme> GetFilmeByIdAsync(int filmeId);
        Task<QueryResult<Filme>> CreateFilmeAsync([FromBody]FilmeModel model);
        Task<QueryResult<Filme>> UpdadeFilmeAsync(int filmeId, [FromBody]FilmeModel model);
        Task<QueryResult<Filme>> DeleteFilmeAsync(int filmeId);
    }
}
