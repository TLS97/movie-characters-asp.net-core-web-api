using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTOs.Characters;
using MovieCharactersAPI.Services.CharacterServices;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _characterService= characterService;
            _mapper = mapper;
        }

        // GET: api/Character
        /// <summary>
        /// Get all the characters in the database.
        /// </summary>
        /// <returns>List of Characters</returns>
        [HttpGet]
        public async Task<ActionResult<ICollection<CharacterDTO>>> GetCharacters()
        {
            return _mapper.Map<List<CharacterDTO>>(await _characterService.GetAllAsync());
        }

        // GET: api/Character/5
        /// <summary>
        /// Gets a specific character from the database by its ID.
        /// </summary>
        /// <param name="id">The character's ID</param>
        /// <returns>A Character object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            Character character = await _characterService.GetByIdAsync(id);

            if (character == null)
            {
                return NotFound();  
            }

            return _mapper.Map<CharacterDTO>(character);
        }

        // PUT: api/Character/5
        /// <summary>
        /// Updates a specific character in the database by its ID.
        /// </summary>
        /// <param name="id">The character's ID</param>
        /// <param name="characterDto">A Character object with updated data</param>
        /// <returns>An Action Result</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterPutDTO characterDto)
        {
            if (id != characterDto.Id)
            {
                return BadRequest();
            }

            if (!_characterService.CharacterExists(id))
            {
                return NotFound();
            }

            Character domainCharacter = _mapper.Map<Character>(characterDto);
            await _characterService.UpdateAsync(domainCharacter);

            return NoContent();
        }

        // POST: api/Character
        /// <summary>
        /// Adds a new character to the database.
        /// </summary>
        /// <param name="characterDto">The character object to add to the database</param>
        /// <returns>An Action Result</returns>
        [HttpPost]
        public async Task<ActionResult<CharacterPostDTO>> PostCharacter(CharacterPostDTO characterDto)
        {
            Character character = _mapper.Map<Character>(characterDto);
            character = await _characterService.AddAsync(character);
            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        // DELETE: api/Character/5
        /// <summary>
        /// Deletes a character from the database by its ID.
        /// </summary>
        /// <param name="id">The character's ID</param>
        /// <returns>An Action Result</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (!_characterService.CharacterExists(id))
            {
                return NotFound();
            }

            await _characterService.DeleteAsync(id);

            return NoContent();
        }
    }
}
