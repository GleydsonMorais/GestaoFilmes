using GestaoFilmesAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace GestaoFilmesAPI.Data.Contexts
{
    public class GestaoFilmesAPIDbContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }

        public GestaoFilmesAPIDbContext(DbContextOptions<GestaoFilmesAPIDbContext> options)
            : base (options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ~~ Filme ~~
            modelBuilder.Entity<Filme>(i =>
            {
                i.ToTable("Filme");
                i.HasKey(x => x.Id);

                i.Property(x => x.Titulo).IsRequired();
                i.Property(x => x.Diretor).IsRequired();

                i.HasOne(x => x.Genero)
                .WithMany(x => x.Filmes)
                .HasForeignKey(x => x.GeneroId);
            });

            modelBuilder.Entity<Genero>(i =>
            {
                i.ToTable("Genero");
                i.HasKey(x => x.Id);

                i.HasMany(x => x.Filmes)
                .WithOne(x => x.Genero)
                .HasForeignKey(x => x.GeneroId);
            });
            #endregion
        }
    }
}
