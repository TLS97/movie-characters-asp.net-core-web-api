using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCharactersAPI.Models
{
    [Table("Character")]
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Picture { get; set; } = null!;

        // Relationship
        public int MovieId { get; set; }

        // Navigation property
        public Movie? Movie { get; set; }
    }
}
