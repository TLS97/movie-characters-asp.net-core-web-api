using Microsoft.Identity.Client;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.CharacterServices
{
    public interface ICharacterService : ICrudService<Character, int>
    {
        public Task<bool> CharacterExists(int id);
    }
}
