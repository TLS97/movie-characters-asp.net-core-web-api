namespace MovieCharactersAPI.Models.DTOs.Characters
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Picture { get; set; } = null!;

        public ICollection<Movie>? Movies { get; set; } = new List<Movie>();
    }
}
