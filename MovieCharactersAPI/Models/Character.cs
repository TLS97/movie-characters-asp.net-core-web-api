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

        // Navigation property
        public ICollection<Movie> Movies { get; set;} = new List<Movie>();
    }
}
