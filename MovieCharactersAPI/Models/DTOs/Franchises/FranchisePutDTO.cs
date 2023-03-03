namespace MovieCharactersAPI.Models.DTOs.Franchises
{
    public class FranchisePutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
