using filmesLand_api.Services;
using filmesLand_api.Shared.Entities;
using filmesLand_api.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmesLand_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly FilmesService _service;

        public MovieController(FilmesService service)
        {
            _service = service;
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMovies()
        {
            return await _service.GetMoviesServices();
        }

        [HttpGet("GetUnrated")]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUnratedMovies()
        {
            return await _service.GetUnratedMoviesServices();
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(FilmeRequest), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMovie([FromBody] FilmeRequest request)
        {
            return await _service.CreateMovieServices(request);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateMovie(int id, FilmeRequest request)
        {
            return await _service.UpdateMovieServices(id, request);
        }

        [HttpPut]
        [Route("Rate/{id:int}")]
        public async Task<IActionResult> RateMovie(int id, float nota)
        {
            return await _service.RateMovieServices(id, nota);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            return await _service.DeleteMovieServices(id);
        }
    }
}