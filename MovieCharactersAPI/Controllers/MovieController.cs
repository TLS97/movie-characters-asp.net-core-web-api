using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTOs.Characters;
using MovieCharactersAPI.Models.DTOs.Franchises;
using MovieCharactersAPI.Models.DTOs.Movies;
using MovieCharactersAPI.Services.MovieServices;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: api/v1/Movie
        /// <summary>
        /// Get all movies in DB
        /// </summary>
        /// <returns>Movie List</returns>
        [HttpGet]
        public async Task<ActionResult<ICollection<MovieDTO>>> GetMovies()
        {
            return Ok(_mapper.Map<List<MovieDTO>>(await _movieService.GetAllAsync()));
        }

        // GET: api/v1/Movie/{id}
        /// <summary>
        /// Get specific movie by ID in DB
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>Movie object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            return Ok(_mapper.Map<MovieDTO>(await _movieService.GetByIdAsync(id)));
        }

        // PUT: api/v1/Movie/{id}
        /// <summary>
        /// Update Movie in DB by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MoviePutDTO movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }

            await _movieService.UpdateAsync(_mapper.Map<Movie>(movie));
            return NoContent();
        }

        // POST: api/v1/Movie
        /// <summary>
        /// Add movie to DB
        /// </summary>
        /// <param name="moviePostDTO"></param>
        /// <returns>Action Result</returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MoviePostDTO moviePostDTO)
        {
            Movie movie = _mapper.Map<Movie>(moviePostDTO);
            await _movieService.AddAsync(movie);
            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/v1/Movie/{id}
        /// <summary>
        /// Delete movie by Id from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }
            await _movieService.DeleteAsync(id);
            return NoContent();
        }

        // GET: api/v1/{id}/characters
        /// <summary>
        /// Get all characters in movie by ID from DB
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>Character List</returns>
        [HttpGet("{id}/characters")]
        public async Task<ICollection<CharacterSummaryDTO>> GetCharactersInMovieAsync(int id)
        {
            return _mapper.Map<List<CharacterSummaryDTO>>(await _movieService.GetCharacters(id));
        }

        // PUT: api/v1/{id}/characters
        /// <summary>
        /// Update characters in a movie by ID in DB
        /// </summary>
        /// <param name="charactersId"></param>
        /// <param name="id">Movie Id</param>
        /// <returns></returns>
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateCharactersInMovieAsync(int[] charactersId, int id)
        {
            await _movieService.UpdateCharactersAsync(charactersId, id);
            return NoContent();
        }
    }
}
