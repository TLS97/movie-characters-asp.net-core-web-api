using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MovieCharactersAPI.Models.Domain
{
    [Table("Movie")]
    public class Movie
    {
        // Primary Key
        public int Id { get; set; }

        // Fields
        [Column(TypeName = "varchar(100)")]
        [NotNull]
        public string Title { get; set; } = null!;
        [Column(TypeName = "varchar(100)")]
        [NotNull]
        public string Genre { get; set; } = null!;
        [Column(TypeName = "int")]
        [NotNull]
        public int ReleaseYear { get; set; }
        [Column(TypeName = "varchar(50)")]
        [NotNull]
        public string Director { get; set; } = null!;
        [Column(TypeName = "varchar(100)")]
        public string Picture { get; set; } = null!;
        [Column(TypeName = "varchar(100)")]
        public string Trailer { get; set; } = null!;

        // Relationships
        public int FranchiseId { get; set; }

        // Navigation properties
        public Franchise? Franchise { get; set; }
        public ICollection<Character>? Characters { get; set; } = new HashSet<Character>();
    }
}
