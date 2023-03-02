using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.DTOs.Characters;
using MovieCharactersAPI.Services.CharacterServices;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly MovieCharactersDbContext _context;
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(MovieCharactersDbContext context, ICharacterService characterService, IMapper mapper)
        {
            _context = context;
            _characterService= characterService;
            _mapper = mapper;
        }

        // GET: api/Character
        [HttpGet]
        public async Task<ActionResult<ICollection<CharacterDTO>>> GetCharacters()
        {
            return _mapper.Map<List<CharacterDTO>>(await _characterService.GetAllAsync());
        }

        // GET: api/Character/5
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterPostDTO>> PostCharacter(CharacterPostDTO characterDto)
        {
            Character character = _mapper.Map<Character>(characterDto);
            character = await _characterService.AddAsync(character);
            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        // DELETE: api/Character/5
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
