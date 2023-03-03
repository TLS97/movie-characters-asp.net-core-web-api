namespace MovieCharactersAPI.Utils.Exceptions
{
    public class FranchiseNotFoundException : EntityNotFoundException
    {
        public FranchiseNotFoundException() : base("Could not find franchise.")
        {
        }
    }
}
