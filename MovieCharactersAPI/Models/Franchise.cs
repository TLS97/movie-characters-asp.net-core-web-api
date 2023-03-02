using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCharactersAPI.Models
{
    [Table("Franchise")]
    public class Franchise
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        // Navigation property
        public ICollection<Movie>? Movies { get; set; } = new HashSet<Movie>();
    }
}
