namespace MovieCharactersAPI.Models.DTOs.Characters
{
    public class CharacterPostDTO
    {
        public string Name { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Picture { get; set; } = null!;
    }
}
