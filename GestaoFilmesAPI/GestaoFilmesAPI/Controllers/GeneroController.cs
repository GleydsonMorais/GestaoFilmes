using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoFilmesAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        // GET: api/<GeneroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _generoService.GetAllGeneroAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
