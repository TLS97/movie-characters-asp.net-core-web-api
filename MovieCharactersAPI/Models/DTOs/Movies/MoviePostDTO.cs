using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Models.DTOs.Movies
{
    public class MoviePostDTO
    {
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Trailer { get; set; } = null!;
        public int FranchiseId { get; set; }
    }
}
