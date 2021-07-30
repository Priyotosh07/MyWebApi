using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using MyWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesApiRepo movieRepository;

        public MoviesController(IMoviesApiRepo movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var movies =  movieRepository.GetMovies();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Movie>> GetMovieByID(int id)
        {
            var movies =  movieRepository.GetmoviesByID(id);
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovies([FromBody] Movie movie)
        {
            int affectedRows =  movieRepository.AddMovies(movie);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMoviesList([FromBody] Movie movie, [FromRoute] int id)
        {
             movieRepository.UpdateMoviesList(movie, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovies([FromRoute] int id)
        {
             movieRepository.DeleteMovies(id);
            return Ok();
        }
    }
}
