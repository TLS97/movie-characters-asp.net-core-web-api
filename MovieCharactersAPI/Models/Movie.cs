using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCharactersAPI.Models
{
    [Table("Movie")]
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Trailer { get; set; } = null!;


        // Relationships
        public int FranchiseId { get; set; }

        // Navigation properties
        public Franchise? Franchise { get; set; }
        public ICollection<Character> Characters { get;set; } = new HashSet<Character>();
    }
}
