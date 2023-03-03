using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Models.DTOs.Franchises
{
    public class FranchiseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<int>? Movies { get; set; } = null!;

    }
}
