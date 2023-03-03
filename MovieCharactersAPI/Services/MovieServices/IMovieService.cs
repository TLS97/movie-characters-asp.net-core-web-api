using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.MovieServices
{
    public interface IMovieService : ICrudService<Movie, int>
    {
        public Task<ICollection<Character>> GetCharacters(int id);
        public Task UpdateCharactersAsync(int[] charactersId, int id);
        public bool MovieExists(int id);
    }
}
