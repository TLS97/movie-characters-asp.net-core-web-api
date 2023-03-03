using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MovieCharactersAPI.Models.Domain
{
    [Table("Character")]
    public class Character
    {
        // Primary Key
        public int Id { get; set; }

        // Fields
        [Column(TypeName = "varchar(50)")]
        [NotNull]
        public string Name { get; set; } = null!;
        [Column(TypeName = "varchar(50)")]
        public string Alias { get; set; } = null!;
        [Column(TypeName = "varchar(50)")]
        [NotNull]
        public string Gender { get; set; } = null!;
        [Column(TypeName = "varchar(255)")]
        public string Picture { get; set; } = null!;

        // Navigation property
        public ICollection<Movie>? Movies { get; set; } = new List<Movie>();
    }
}
