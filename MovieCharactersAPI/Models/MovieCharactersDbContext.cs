using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Models
{
    public class MovieCharactersDbContext : DbContext
    {
        public MovieCharactersDbContext(DbContextOptions options) : base(options)
        {
        }

        // Tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Franchise>().HasData(
                new Franchise()
                {
                    Id = 1,
                    Name = "Franchise1",
                    Description = "blabla"
                });
            
            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1,
                    Title = "Movie1",
                    Director = "director",
                    Genre = "genre",
                    ReleaseYear = 3000,
                    Picture = "picture url",
                    Trailer = "trailer url",
                    FranchiseId = 1
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Movie2",
                    Director = "director",
                    Genre = "genre",
                    ReleaseYear = 1990,
                    Picture = "picture url",
                    Trailer = "trailer url",
                    FranchiseId = 1
                });

            modelBuilder.Entity<Character>().HasData(
                new Character()
                {
                    Id = 1,
                    Name = "Character1",
                    Alias = "alias",
                    Gender = "F",
                    Picture = "picture url"
                },
                new Character()
                {
                    Id = 2,
                    Name = "Character2",
                    Alias = "alias",
                    Gender = "F",
                    Picture = "picture url"
                },
                new Character()
                {
                    Id = 3,
                    Name = "Character3",
                    Alias = "alias",
                    Gender = "F",
                    Picture = "picture url"
                },
                new Character()
                {
                    Id = 4,
                    Name = "Character4",
                    Alias = "alias",
                    Gender = "F",
                    Picture = "picture url"
                });

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Characters)
                .WithMany(c => c.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "Roles",
                    r => r.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("CharacterId", "MovieId");
                        je.HasData(
                            new { CharacterId = 1, MovieId = 1 },
                            new { CharacterId = 2, MovieId = 1 },
                            new { CharacterId = 3, MovieId = 2 },
                            new { CharacterId = 4, MovieId = 2 }
                        );
                    });
        }
    }
}
