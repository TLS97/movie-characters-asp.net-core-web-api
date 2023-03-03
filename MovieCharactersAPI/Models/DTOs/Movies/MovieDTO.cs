using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Models.DTOs.Movies
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public DateTime Release { get; set; }
        public string Director { get; set; } = null!;
        public string TrailerUrl { get; set; } = null!;
        public int FranchiseId { get; set; }
        public ICollection<Character> Characters { get; set; } = null!;

    }
}
