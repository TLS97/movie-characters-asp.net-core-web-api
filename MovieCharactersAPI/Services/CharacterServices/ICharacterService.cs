using Microsoft.Identity.Client;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services.CharacterServices
{
    public interface ICharacterService : ICrudService<Character, int>
    {
        public bool CharacterExists(int id);
    }
}
