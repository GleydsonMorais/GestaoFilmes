using GestaoFilmesAPI.Data.Constants;
using GestaoFilmesAPI.Data.Contexts;
using GestaoFilmesAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFilmesAPI.Data
{
    public class GestaoFilmesAPIDbSeeder
    {
        public static async Task Initialize(GestaoFilmesAPIDbContext context)
        {
            await context.Database.MigrateAsync();

            if (!context.Generos.Any())
                await CreateGeneroAsync(context);
        }

        private static async Task CreateGeneroAsync(GestaoFilmesAPIDbContext context)
        {
            var listGenero = new List<Genero>
            {
                new Genero { Descricao = GenerosConstants.Acao },
                new Genero { Descricao = GenerosConstants.Aventura },
                new Genero { Descricao = GenerosConstants.Comedia },
                new Genero { Descricao = GenerosConstants.Drama },
                new Genero { Descricao = GenerosConstants.Faroeste },
                new Genero { Descricao = GenerosConstants.Musical },
                new Genero { Descricao = GenerosConstants.Romance },
                new Genero { Descricao = GenerosConstants.Terror }
            };

            await context.AddRangeAsync(listGenero);
            await context.SaveChangesAsync();
        }
    }
}
