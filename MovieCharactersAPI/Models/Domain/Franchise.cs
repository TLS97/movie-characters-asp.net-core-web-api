using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MovieCharactersAPI.Models.Domain
{
    [Table("Franchise")]
    public class Franchise
    {
        // Primary Key
        public int Id { get; set; }

        // Fields
        [Column(TypeName = "varchar(50)")]
        [NotNull]
        public string Name { get; set; } = null!;
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; } = null!;

        // Navigation property
        public ICollection<Movie>? Movies { get; set; } = new HashSet<Movie>();
    }
}
