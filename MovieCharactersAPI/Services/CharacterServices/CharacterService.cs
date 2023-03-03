using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Utils.Exceptions;

namespace MovieCharactersAPI.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieCharactersDbContext _context;

        public CharacterService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            if (! await CharacterExists(id))
            {
                throw new CharacterNotFoundException();
            }

            return await _context.Characters.FindAsync(id);
        }

        public async Task UpdateAsync(Character entity)
        {
            if (! await CharacterExists(entity.Id)) 
            { 
                throw new CharacterNotFoundException(); 
            
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Character> AddAsync(Character entity)
        {
            await _context.Characters.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> CharacterExists(int id)
        {
            return await _context.Characters.AnyAsync(c => c.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                throw new CharacterNotFoundException();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
    }
}
