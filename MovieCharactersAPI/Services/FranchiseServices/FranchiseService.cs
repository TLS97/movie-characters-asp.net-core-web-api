using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Utils;
using MovieCharactersAPI.Utils.Exceptions;

namespace MovieCharactersAPI.Services.FranchiseServices
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieCharactersDbContext _context;

        public FranchiseService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task<Franchise> AddAsync(Franchise entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Franchise>> GetAllAsync()
        {
            return await _context.Franchises.Include(f => f.Movies).ToListAsync();
        }

        public async Task<Franchise> GetByIdAsync(int id)
        {
            return await _context.Franchises.FindAsync(id);
        }

        public async Task<ICollection<Character>> GetCharactersAsync(int franchiseId)
        {
            if (!FranchiseExists(franchiseId))
            {
                throw new FranchiseNotFoundException();
            }
            Franchise franchise = await _context.Franchises
                .Where(f => f.Id == franchiseId)
                .Include(f => f.Movies)
                .ThenInclude(m => m.Characters)
                .FirstAsync();
            ICollection<Character> characters = new List<Character>();
            foreach (var movie in franchise.Movies)
            {
                foreach (var character in movie.Characters)
                {
                    if (!characters.Contains(character))
                    {
                        characters.Add(character);
                    }
                }
            }
            return characters;
        }

        public async Task<ICollection<Movie>> GetMoviesAsync(int franchiseId)
        {
            return await _context.Movies.Where(m => m.FranchiseId == franchiseId).ToListAsync();
        }

        public async Task UpdateAsync(Franchise entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMoviesAsync(int[] movieId, int franchiseId)
        {
            if (!FranchiseExists(franchiseId))
            {
                throw new FranchiseNotFoundException();
            }
            List<Movie> movies = movieId.ToList()
                .Select (movieId => _context.Movies
                .Where (m => m.Id == movieId).First())
                .ToList();
            Franchise franchise = await _context.Franchises
                .Where(f => f.Id == franchiseId)
                .FirstAsync();
            franchise.Movies = movies;
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool FranchiseExists(int id)
        {
            return _context.Franchises.Any(f => f.Id == id);
        }
    }
}
