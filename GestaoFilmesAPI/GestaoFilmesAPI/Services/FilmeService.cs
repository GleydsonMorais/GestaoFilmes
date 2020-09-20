using GestaoFilmesAPI.Data.Helpers;
using GestaoFilmesAPI.Data.Models;
using GestaoFilmesAPI.Data.Repositories;
using GestaoFilmesAPI.Interfaces;
using GestaoFilmesAPI.Models.Filme;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFilmesAPI.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IGeneroRepository _generoRepository;

        public FilmeService(IFilmeRepository filmeRepository,
            IGeneroRepository generoRepository)
        {
            _filmeRepository = filmeRepository;
            _generoRepository = generoRepository;
        }

        public async Task<IList<Filme>> GetAllFilmeAsync() => await _filmeRepository.AllAsync();

        public async Task<Filme> GetFilmeByIdAsync(int filmeId) => await _filmeRepository.GetByIdAsync(filmeId);

        public async Task<QueryResult<Filme>> CreateFilmeAsync([FromBody]FilmeModel model)
        {
            if (!string.IsNullOrEmpty(model.Titulo))
            {
                if (!string.IsNullOrEmpty(model.Diretor))
                {
                    var genero = await _generoRepository.GetByIdAsync(model.GeneroId);
                    if (genero != null)
                    {
                        if (model.Ano.HasValue == false || (model.Ano.Value > 0 && model.Ano.Value <= 9999))
                        { 
                            var filme = new Filme
                            { 
                                Titulo = model.Titulo,
                                Diretor = model.Diretor,
                                GeneroId = model.GeneroId,
                                Sinopse = model.Sinopse,
                                Ano = model.Ano
                            };

                            await _filmeRepository.InsertAsync(filme);
                            await _filmeRepository.SaveAsync();

                            return new QueryResult<Filme>
                            {
                                Succeeded = true,
                                Result = filme
                            };
                        }
                        else
                        {
                            return new QueryResult<Filme>
                            {
                                Succeeded = false,
                                Message = "Ano inválido!"
                            };
                    }
                    }
                    else
                    {
                        return new QueryResult<Filme>
                        {
                            Succeeded = false,
                            Message = "Genero não cadastrado!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Filme>
                    {
                        Succeeded = false,
                        Message = "O campo Diretor é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Filme>
                {
                    Succeeded = false,
                    Message = "O campo Título é obrigatório!"
                };
            }
        }

        public async Task<QueryResult<Filme>> UpdadeFilmeAsync(int filmeId, [FromBody]FilmeModel model)
        {
            var filme = await _filmeRepository.GetByIdAsync(filmeId);
            if (filme != null)
            {
                if (!string.IsNullOrEmpty(model.Titulo))
                {
                    if (!string.IsNullOrEmpty(model.Diretor))
                    {
                        var genero = await _generoRepository.GetByIdAsync(model.GeneroId);
                        if (genero != null)
                        {
                            if (model.Ano.HasValue == false || (model.Ano.Value > 0 && model.Ano.Value <= 9999))
                            {
                                filme.Titulo = model.Titulo;
                                filme.Diretor = model.Diretor;
                                filme.GeneroId = model.GeneroId;
                                filme.Sinopse = model.Sinopse;
                                filme.Ano = model.Ano;

                                _filmeRepository.Update(filme);
                                await _filmeRepository.SaveAsync();

                                return new QueryResult<Filme>
                                {
                                    Succeeded = true,
                                    Result = filme
                                };
                            }
                            else
                            {
                                return new QueryResult<Filme>
                                {
                                    Succeeded = false,
                                    Message = "Ano inválido!"
                                };
                            }
                        }
                        else
                        {
                            return new QueryResult<Filme>
                            {
                                Succeeded = false,
                                Message = "Genero não cadastrado!"
                            };
                        }
                    }
                    else
                    {
                        return new QueryResult<Filme>
                        {
                            Succeeded = false,
                            Message = "O campo Diretor é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Filme>
                    {
                        Succeeded = false,
                        Message = "O campo Título é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Filme>
                {
                    Succeeded = false,
                    Message = "Filme não encontrado!"
                };
            }
        }

        public async Task<QueryResult<Filme>> DeleteFilmeAsync(int filmeId)
        {
            var filme = await _filmeRepository.GetByIdAsync(filmeId);
            if (filme != null)
            {
                _filmeRepository.Delete(filme);
                await _filmeRepository.SaveAsync();

                return new QueryResult<Filme>
                {
                    Succeeded = true,
                    Message = "Filme deletado com sucesso."
                };
            }
            else
            {
                return new QueryResult<Filme>
                {
                    Succeeded = false,
                    Message = "Filme não encontrado!"
                };
            }
        }
    }
}
