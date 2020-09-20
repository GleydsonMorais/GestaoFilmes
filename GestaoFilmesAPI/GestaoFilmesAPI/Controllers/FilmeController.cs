using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoFilmesAPI.Data.Models;
using GestaoFilmesAPI.Interfaces;
using GestaoFilmesAPI.Models.Filme;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestaoFilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        // GET: api/<FilmeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _filmeService.GetAllFilmeAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // GET api/<FilmeController>/5
        [HttpGet("{filmeId}")]
        public async Task<IActionResult> Get(int filmeId)
        {
            try
            {
                var result = await _filmeService.GetFilmeByIdAsync(filmeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // POST api/<FilmeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FilmeModel model)
        {
            try
            {
                var result = await _filmeService.CreateFilmeAsync(model);
                if (result.Succeeded)
                    return Ok(result.Result);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // PUT api/<FilmeController>/5
        [HttpPut("{filmeId}")]
        public async Task<IActionResult> Put(int filmeId, [FromBody]FilmeModel model)
        {
            try
            {
                var result = await _filmeService.UpdadeFilmeAsync(filmeId, model);
                if (result.Succeeded)
                    return Ok(result.Result);
                else
                    return NotFound(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // DELETE api/<FilmeController>/5
        [HttpDelete("{filmeId}")]
        public async Task<IActionResult> Delete(int filmeId)
        {
            try
            {
                var result = await _filmeService.DeleteFilmeAsync(filmeId);
                if (result.Succeeded)
                    return Ok(result.Message);
                else
                    return NotFound(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
