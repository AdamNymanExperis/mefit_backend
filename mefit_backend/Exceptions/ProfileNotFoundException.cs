namespace mefit_backend.Exceptions
{
    public class ProfileNotFoundException : Exception
    {
        public ProfileNotFoundException(int id) : base($"Profile with id {id} was not found")
        {

        }
    }
}
