using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.FranchiseServices
{
    public interface IFranchiseService : ICrudService<Franchise, int>
    {
        Task UpdateMoviesAsync(int[] movieId, int franchiseId);
        Task<ICollection<Character>> GetCharactersAsync(int franchiseId);
        Task<ICollection<Movie>> GetMoviesAsync(int franchiseId);
        bool FranchiseExists(int id);
    }
}
