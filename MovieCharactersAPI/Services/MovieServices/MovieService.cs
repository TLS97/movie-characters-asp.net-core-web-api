using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Utils.Exceptions;

namespace MovieCharactersAPI.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly MovieCharactersDbContext _context;

        public MovieService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddAsync(Movie entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            if(!MovieExists(id))
            {
                throw new MovieNotFoundException();
            }
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Movie>> GetAllAsync()
        {
            return await _context.Movies.Include(m => m.Characters).ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<ICollection<Character>> GetCharacters(int id)
        {
            if(!MovieExists(id))
            {
                throw new MovieNotFoundException();
            }
            
            return await _context.Movies.Where(m => m.Id == id).Include(m => m.Characters).Select(m => m.Characters).FirstAsync();
        }

        public async Task UpdateAsync(Movie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCharactersAsync(int[] charactersId, int id)
        {
            if(!MovieExists(id))
            {
                throw new MovieNotFoundException();
            }

            List<Character> characters = charactersId.ToList()
                .Select(cId => _context.Characters
                .Where(c => c.Id == cId).First()).ToList();

            Movie movie = await _context.Movies
                .Where(m => m.Id == id)
                .Include(m => m.Characters)
                .FirstAsync();
            movie.Characters = characters;
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool MovieExists(int id)
        {
            return _context.Movies.Any(m => m.Id == id);
        }
    }
}
