namespace MovieCharactersAPI.Utils.Exceptions
{
    public class CharacterNotFoundException : EntityNotFoundException
    {
        public CharacterNotFoundException() : base("No Character with that ID found.")
        {
        }
    }
}
