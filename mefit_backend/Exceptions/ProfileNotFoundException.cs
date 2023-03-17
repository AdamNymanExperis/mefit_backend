namespace mefit_backend.Exceptions
{
    public class ProfileNotFoundException : Exception
    {
        public ProfileNotFoundException(string id) : base($"Profile with id {id} was not found")
        {

        }
    }
}
