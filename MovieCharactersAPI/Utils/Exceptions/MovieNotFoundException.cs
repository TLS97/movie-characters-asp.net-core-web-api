namespace MovieCharactersAPI.Utils.Exceptions
{
    public class MovieNotFoundException : EntityNotFoundException
    {
        public MovieNotFoundException() : base("Could not find movie.")
        {
        }
    }
}
