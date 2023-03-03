using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using MovieCharactersAPI.Services.FranchiseServices;
using MovieCharactersAPI.Utils.Exceptions;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchiseController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchiseController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        // GET: api/v1/Franchise
        /// <summary>
        /// Get all franchises from DB
        /// </summary>
        /// <returns>Franchises List</returns>
        [HttpGet]
        public async Task<ActionResult<ICollection<FranchiseDTO>>> GetFranchises()
        {
            return Ok(_mapper.Map<List<FranchiseDTO>>(await _franchiseService.GetAllAsync()));
        }

        // GET: api/v1/Franchise/{id}
        /// <summary>
        /// Get specific franchise by id from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Franchise object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            return Ok(_mapper.Map<FranchiseDTO>(await _franchiseService.GetByIdAsync(id)));
        }

        // PUT: api/Franchise/{id}
        /// <summary>
        /// Update franchise in DB by its ID
        /// </summary>
        /// <param name="id">Franchise ID</param>
        /// <param name="franchisePutDTO"></param>
        /// <returns>Action Result</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDTO franchisePutDTO)
        {
            if (id != franchisePutDTO.Id)
            {
                return BadRequest();
            }
            if (!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }

            await _franchiseService.UpdateAsync(_mapper.Map<Franchise>(franchisePutDTO));
            return NoContent();
;
        }

        // POST: api/v1/Franchise
        /// <summary>
        /// Add a new franchise to DB
        /// </summary>
        /// <param name="franchiseDTO"></param>
        /// <returns>Action result</returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchisePostDTO franchisePostDTO)
        {
            Franchise franchise = _mapper.Map<Franchise>(franchisePostDTO);
            await _franchiseService.AddAsync(franchise);
            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // DELETE: api/v1/Franchise/{id}
        /// <summary>
        /// Deletes a franchise from the DB by its ID.
        /// </summary>
        /// <param name="id">The franchise's ID</param>
        /// <returns>An Action Result</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }
            await _franchiseService.DeleteAsync(id);
            return NoContent();
        }

        // GET: api/v1/{id}/characters
        /// <summary>
        /// Get all unique characters in a franchise by id
        /// </summary>
        /// <param name="id">Franchise ID</param>
        /// <returns>Character list</returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<CharacterSummaryDTO>> GetCharactersInFranchise(int id)
        {
            return Ok(_mapper.Map<List<CharacterSummaryDTO>>(await _franchiseService.GetCharactersAsync(id)));
        }
        
        // GET: api/v1/Franchise/{id}
        /// <summary>
        /// Get movies in franchises from DB by franchise id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie list</returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieSummaryDTO>>> GetMoviesInFranchiseAsync(int id)
        {
            return _mapper.Map<List<MovieSummaryDTO>>(await _franchiseService.GetMoviesAsync(id));

        }

        // POST: api/v1/Franchise/{id}/movies
        /// <summary>
        /// Update movies by id in franchise by id in DB
        /// </summary>
        /// <param name="movieId">Movie ID</param>
        /// <param name="id">Franchise ID</param>
        /// <returns>NoContent</returns>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateMoviesInFranchiseAsync(int[] movieId, int id)
        {
            await _franchiseService.UpdateMoviesAsync(movieId, id);
            return NoContent();
        }


    }
}
